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

public class FadeOut : GUIEffect
{


    public float animationVelocity;
    public float originalAlpha;

    CanvasRenderer canvasRenderer;

    void Awake()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();
        originalAlpha = canvasRenderer.GetAlpha();
    }

    // Use this for initialization
    void Start()
    {
        base.Start();      
        reset();
    }

    // Update is called once per frame
    public override void EffectUpdate()
    {
        
        float currentAlpha = canvasRenderer.GetAlpha();
        float lerpedAlpha = Mathf.MoveTowards(currentAlpha, 0, animationVelocity * Time.deltaTime);
        canvasRenderer.SetAlpha(lerpedAlpha);

        if(canvasRenderer.GetAlpha() == 0)
        {
            isExecuting = false;
        }

    }



    public override IEnumerator startEffect()
    {
        //canvasRenderer.SetAlpha(originalAlpha);
        isExecuting = true;
        isFinished = false;
        yield return null;
    }


    public override void reset()
    {
        canvasRenderer.SetAlpha(originalAlpha);
        isExecuting = false;
        isFinished = false;
    }

}
