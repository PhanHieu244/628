/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

using UnityEngine;
using System.Collections;

public class ClickControl : MonoBehaviour {


    public static ClickControl instance;


    float scrWidth;
    void Start() {
        scrWidth = Screen.width;
    }

    void Awake()
    {
        instance = this;
    }

  

    public bool isLeftScreenTouched() {

        foreach (Touch touch in Input.touches)
        {

            if (touch.position.x < scrWidth / 2)
            {
                return true; 

            }
  

        }


#if UNITY_EDITOR
        if (Input.GetMouseButton(0) == true && Input.mousePosition.x < scrWidth / 2) return true;
#endif


        return false;


    }


    public bool isRightScreenTouched()
    {

        foreach (Touch touch in Input.touches)
        {

            if (touch.position.x > scrWidth / 2)
            {
                return true;

            }


        }

#if UNITY_EDITOR
        if (Input.GetMouseButton(0)==true && Input.mousePosition.x > scrWidth / 2) return true;
#endif

        return false;


    }






}
