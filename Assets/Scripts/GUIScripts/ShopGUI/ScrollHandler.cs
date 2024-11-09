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

public class ScrollHandler : MonoBehaviour
{

    float previousMousePosition = 0;
    float newMousePosition = 0;

    public float positionVariation;
    public bool isScrolling;

    public float scrollPower;

    public static ScrollHandler instance;


    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        decreaseScrollPower();
        if (Input.GetMouseButton(0))
        {
            newMousePosition = Input.mousePosition.x;
            if (!isScrolling)
            {
                previousMousePosition = newMousePosition;
            }
            else {


                positionVariation = newMousePosition - previousMousePosition;
                previousMousePosition = newMousePosition;
                scrollPower = positionVariation;


            }


            isScrolling = true;
        }
        else
        {
            isScrolling = false;
        }
    }

    void decreaseScrollPower()
    {
        if (scrollPower > 0)
        {
            scrollPower -= 3f;
            if (Mathf.Round(scrollPower) < 5)
            {
                scrollPower = 0;
            }
        }
        if (scrollPower < 0)
        {
            scrollPower += 3f;
            if (Mathf.Round(scrollPower) > -5)
            {
                scrollPower = 0;
            }
        }


    }
}
