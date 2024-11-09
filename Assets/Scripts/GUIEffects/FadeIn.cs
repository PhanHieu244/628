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

public class FadeIn : GUIEffect
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
        float lerpedAlpha = Mathf.MoveTowards(currentAlpha, originalAlpha, animationVelocity * Time.deltaTime);
        canvasRenderer.SetAlpha(lerpedAlpha);

        if (canvasRenderer.GetAlpha() == originalAlpha)
        {
            isExecuting = false;
        }
    }

    void OnEnable()
    {
        canvasRenderer.SetAlpha(0);
    }

    public override IEnumerator startEffect()
    {       
        isExecuting = true;
        isFinished = false;
        yield return null;
    }


    public override void reset()
    {
        canvasRenderer.SetAlpha(0);
        isExecuting = false;
        isFinished = false;
    }

}
