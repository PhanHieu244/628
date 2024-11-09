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

public class GUIEffect : MonoBehaviour {

    public  GUIEffect startAfterThisEffect;
    public float secondsToWaitToStart;

    public virtual RectTransform rect
    {
        get;
        set;
    }

    public virtual bool isExecuting
    {
        get;
        set;
    }

    public virtual bool isFinished
    {
        get;
        set;
    }

    public virtual void Awake()
    {
       // rect = getRect();
    }

    public virtual void Start()
    {

    }

    // Use this for initialization
    public virtual void Initialize () {
        rect = getRect();
	}
	
	// Update is called once per frame
	void Update () {

        if (isExecuting)
        {
            EffectUpdate();
        }

    }

    void OnDisable()
    {
        isExecuting = false;
    }

    public virtual void EffectUpdate()
    {

    }

    public virtual IEnumerator startEffect()
    {      

        yield return new WaitForSeconds(secondsToWaitToStart);
        yield return StartCoroutine(effect());
    }

    public virtual void reset()
    {

    }

    public virtual IEnumerator effect()
    {
        yield return null;
    }

    public virtual RectTransform getRect()
    {
        return GetComponent<RectTransform>();
    }


 

}
