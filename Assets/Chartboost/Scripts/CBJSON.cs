/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

using System;
using System.Collections;
using System.IO;
using System.Text;

namespace ChartboostSDK {
    public static class CBJSON {
        /// <summary>
        /// Parses the string json into a value
        /// </summary>
        /// <param name="json">A JSON string.</param>
        /// <returns>An ArrayList, a Hashtable, a double, an integer,a string, null, true, or false</returns>
        public static object Deserialize(string json) {
            // save the string for debug information
            if (json == null) {
                return null;
            }

            return Parser.Parse(json);
        }

        sealed class Parser : IDisposable {
            const string WORD_BREAK = "{}[],:\"";

            public static bool IsWordBreak(char c) {
                return Char.IsWhiteSpace(c) || WORD_BREAK.IndexOf(c) != -1;
            }

            enum TOKEN {
                NONE,
                CURLY_OPEN,
                CURLY_CLOSE,
                SQUARED_OPEN,
                SQUARED_CLOSE,
                COLON,
                COMMA,
                STRING,
                NUMBER,
                TRUE,
                FALSE,
                NULL
            };

            StringReader json;

            Parser(string jsonString) {
                json = new StringReader(jsonString);
            }

            public static object Parse(string jsonString) {
                using (var instance = new Parser(jsonString)) {
                    return instance.ParseValue();
                }
            }

            public void Dispose() {
                json.Dispose();
                json = null;
            }

            Hashtable ParseObject() {
                Hashtable table = new Hashtable();

                // ditch opening brace
                json.Read();

                // {
                while (true) {
                    switch (NextToken) {
                    case TOKEN.NONE:
                        return null;
                    case TOKEN.COMMA:
                        continue;
                    case TOKEN.CURLY_CLOSE:
                        return table;
                    default:
                        // name
                        string name = ParseString();
                        if (name == null) {
                            return null;
                        }

                        // :
                        if (NextToken != TOKEN.COLON) {
                            return null;
                        }
                        // ditch the colon
                        json.Read();

                        // value
                        table[name] = ParseValue();
                        break;
                    }
                }
            }

            ArrayList ParseArray() {
                ArrayList array = new ArrayList();

                // ditch opening bracket
                json.Read();

                // [
                var parsing = true;
                while (parsing) {
                    TOKEN nextToken = NextToken;

                    switch (nextToken) {
                    case TOKEN.NONE:
                        return null;
                    case TOKEN.COMMA:
                        continue;
                    case TOKEN.SQUARED_CLOSE:
                        parsing = false;
                        break;
                    default:
                        object nextValue = ParseByToken(nextToken);

                        array.Add(nextValue);
                        break;
                    }
                }

                return array;
            }

            object ParseValue() {
                TOKEN nextToken = NextToken;
                return ParseByToken(nextToken);
            }

            object ParseByToken(TOKEN token) {
                switch (token) {
                case TOKEN.STRING:
                    return ParseString();
                case TOKEN.NUMBER:
                    return ParseNumber();
                case TOKEN.CURLY_OPEN:
                    return ParseObject();
                case TOKEN.SQUARED_OPEN:
                    return ParseArray();
                case TOKEN.TRUE:
                    return true;
                case TOKEN.FALSE:
                    return false;
                case TOKEN.NULL:
                    return null;
                default:
                    return null;
                }
            }

            string ParseString() {
                StringBuilder s = new StringBuilder();
                char c;

                // ditch opening quote
                json.Read();

                bool parsing = true;
                while (parsing) {

                    if (json.Peek() == -1) {
                        parsing = false;
                        break;
                    }

                    c = NextChar;
                    switch (c) {
                    case '"':
                        parsing = false;
                        break;
                    case '\\':
                        if (json.Peek() == -1) {
                            parsing = false;
                            break;
                        }

                        c = NextChar;
                        switch (c) {
                        case '"':
                        case '\\':
                        case '/':
                            s.Append(c);
                            break;
                        case 'b':
                            s.Append('\b');
                            break;
                        case 'f':
                            s.Append('\f');
                            break;
                        case 'n':
                            s.Append('\n');
                            break;
                        case 'r':
                            s.Append('\r');
                            break;
                        case 't':
                            s.Append('\t');
                            break;
                        case 'u':
                            var hex = new char[4];

                            for (int i=0; i< 4; i++) {
                                hex[i] = NextChar;
                            }

                            s.Append((char) Convert.ToInt32(new string(hex), 16));
                            break;
                        }
                        break;
                    default:
                        s.Append(c);
                        break;
                    }
                }

                return s.ToString();
            }

            object ParseNumber() {
                string number = NextWord;

                if (number.IndexOf('.') == -1) {
                    long parsedInt;
                    Int64.TryParse(number, out parsedInt);
                    return parsedInt;
                }

                double parsedDouble;
                Double.TryParse(number, out parsedDouble);
                return parsedDouble;
            }

            void EatWhitespace() {
                while (Char.IsWhiteSpace(PeekChar)) {
                    json.Read();

                    if (json.Peek() == -1) {
                        break;
                    }
                }
            }

            char PeekChar {
                get {
                    return Convert.ToChar(json.Peek());
                }
            }

            char NextChar {
                get {
                    return Convert.ToChar(json.Read());
                }
            }

            string NextWord {
                get {
                    StringBuilder word = new StringBuilder();

                    while (!IsWordBreak(PeekChar)) {
                        word.Append(NextChar);

                        if (json.Peek() == -1) {
                            break;
                        }
                    }

                    return word.ToString();
                }
            }

            TOKEN NextToken {
                get {
                    EatWhitespace();

                    if (json.Peek() == -1) {
                        return TOKEN.NONE;
                    }

                    switch (PeekChar) {
                    case '{':
                        return TOKEN.CURLY_OPEN;
                    case '}':
                        json.Read();
                        return TOKEN.CURLY_CLOSE;
                    case '[':
                        return TOKEN.SQUARED_OPEN;
                    case ']':
                        json.Read();
                        return TOKEN.SQUARED_CLOSE;
                    case ',':
                        json.Read();
                        return TOKEN.COMMA;
                    case '"':
                        return TOKEN.STRING;
                    case ':':
                        return TOKEN.COLON;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '-':
                        return TOKEN.NUMBER;
                    }

                    switch (NextWord) {
                    case "false":
                        return TOKEN.FALSE;
                    case "true":
                        return TOKEN.TRUE;
                    case "null":
                        return TOKEN.NULL;
                    }

                    return TOKEN.NONE;
                }
            }
        }

        /// <summary>
        /// Converts a Hashtable / ArrayList object or a simple type (string, int, etc.) into a JSON string
        /// </summary>
        /// <param name="json">A Hashtable / Arraylist</param>
        /// <returns>A JSON encoded string, or null if object 'json' is not serializable</returns>
        public static string Serialize(object obj) {
            return Serializer.Serialize(obj);
        }

        sealed class Serializer {
            StringBuilder builder;

            Serializer() {
                builder = new StringBuilder();
            }

            public static string Serialize(object obj) {
                var instance = new Serializer();

                instance.SerializeValue(obj);

                return instance.builder.ToString();
            }

            void SerializeValue(object val) {
                ArrayList asList;
                Hashtable asDict;
                string asStr;

                if (val == null) {
                    builder.Append("null");
                } else if ((asStr = val as string) != null) {
                    SerializeString(asStr);
                } else if (val is bool) {
                    builder.Append((bool) val ? "true" : "false");
                } else if ((asList = val as ArrayList) != null) {
                    SerializeArray(asList);
                } else if ((asDict = val as Hashtable) != null) {
                    SerializeObject(asDict);
                } else if (val is char) {
                    SerializeString(new string((char) val, 1));
                } else {
                    SerializeOther(val);
                }
            }

            void SerializeObject(Hashtable obj) {
                bool first = true;

                builder.Append('{');
				
				foreach (DictionaryEntry e in obj) {
                    if (!first) {
                        builder.Append(',');
                    }

                    SerializeString(e.Key.ToString());
                    builder.Append(':');

                    SerializeValue(e.Value);

                    first = false;
                }

                builder.Append('}');
            }

            void SerializeArray(ArrayList anArray) {
                builder.Append('[');

                bool first = true;
				
				for (int i = 0; i < anArray.Count; i++) {
					object obj = anArray[i];
                    if (!first) {
                        builder.Append(',');
                    }

                    SerializeValue(obj);

                    first = false;
                }

                builder.Append(']');
            }

            void SerializeString(string str) {
                builder.Append('\"');

                char[] charArray = str.ToCharArray();
				for (int i = 0; i < charArray.Length; i++) {
					char c = charArray[i];
                    switch (c) {
                    case '"':
                        builder.Append("\\\"");
                        break;
                    case '\\':
                        builder.Append("\\\\");
                        break;
                    case '\b':
                        builder.Append("\\b");
                        break;
                    case '\f':
                        builder.Append("\\f");
                        break;
                    case '\n':
                        builder.Append("\\n");
                        break;
                    case '\r':
                        builder.Append("\\r");
                        break;
                    case '\t':
                        builder.Append("\\t");
                        break;
                    default:
                        int codepoint = Convert.ToInt32(c);
                        if ((codepoint >= 32) && (codepoint <= 126)) {
                            builder.Append(c);
                        } else {
                            builder.Append("\\u");
                            builder.Append(codepoint.ToString("x4"));
                        }
                        break;
                    }
                }

                builder.Append('\"');
            }

            void SerializeOther(object val) {
                // NOTE: decimals lose precision during serialization.
                // They always have, I'm just letting you know.
                // Previously floats and doubles lost precision too.
                if (val is float) {
                    builder.Append(((float) val).ToString("R"));
                } else if (val is int
                    || val is uint
                    || val is long
                    || val is sbyte
                    || val is byte
                    || val is short
                    || val is ushort
                    || val is ulong) {
                    builder.Append(val);
                } else if (val is double
                    || val is decimal) {
                    builder.Append(Convert.ToDouble(val).ToString("R"));
                } else {
                    SerializeString(val.ToString());
                }
            }
        }
    }
}
