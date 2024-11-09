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

public class ShopItem : MonoBehaviour {

    //THESE VALUES ARE REFERENCES FOR THE STORE

    public int price;
    //THESE VALUES ARE REFERENCES FOR THE STORE

    public SpriteRenderer sprite;


    public Vector3 originalScale;

    [HideInInspector]
    public bool unlocked;

    public bool unlockedByDefault;

    // Use this for initialization
    void Awake()
    {

       
        originalScale = transform.localScale;

    }

    void Start () {

        if (ShopHandler.instance.GetBoughtItemsNames().Contains(gameObject.name)  || unlockedByDefault)
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }

	}
	
	// Update is called once per frame
	void Update () {

	
	}


    public void Buy()
    {
        unlocked = true;
        ShopHandler.instance.UnlockShopItem(this);
    }



}
