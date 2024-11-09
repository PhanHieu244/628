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

public class Cube : MonoBehaviour
{

    public Eye eye;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (eye.gameObject.name != ShopHandler.instance.shopItemToUse.gameObject.name)
        {
            Eye selectedEye = ShopHandler.instance.shopItemToUse.GetComponent<Eye>();
            eye.baseSprite.sprite = selectedEye.baseSprite.sprite;
            eye.pupil.sprite = selectedEye.pupil.sprite;
            eye.gameObject.name = selectedEye.gameObject.name;

        }
    }
}
