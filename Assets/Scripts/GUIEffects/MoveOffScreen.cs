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

public class MoveOffScreen : GUIEffect
{


    public enum Side { top, bottom, left, right };
    public Side side;

    public float animationVelocity;
    Vector2 targetPoint;

    public RectTransform canvasParentRect;
    public Vector2 parentCanvasSize;

    public Vector2 originalPosition;

    void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {
        base.Start();
        originalPosition = rect.anchoredPosition;
        reset();
    }

    // Update is called once per frame
    public override void EffectUpdate()
    {


        rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition, targetPoint, animationVelocity * Time.deltaTime);



        if (rect.anchoredPosition == targetPoint)
        {
            isExecuting = false;
            isFinished = true;
        }
    }

    public void setTargetPosition()
    {
        switch (side)
        {
            case Side.bottom:
                targetPoint = new Vector2(targetPoint.x, -parentCanvasSize.y / 2 - rect.rect.height / 2);
                break;
            case Side.top:
                targetPoint = new Vector2(targetPoint.x, parentCanvasSize.y / 2 + rect.rect.height / 2);
                break;
            case Side.right:
                targetPoint = new Vector2(parentCanvasSize.x / 2 + rect.rect.width / 2, targetPoint.y);
                break;
            case Side.left:
                targetPoint = new Vector2(-parentCanvasSize.x / 2 - rect.rect.width / 2, targetPoint.y);
                break;
        }
    }
    public override IEnumerator startEffect()
    {
        rect.anchoredPosition = originalPosition;
        setTargetPosition();
        isExecuting = true;
        isFinished = false;
        yield return null;
    }


    public override void reset()
    {
        parentCanvasSize = new Vector2(canvasParentRect.rect.width, canvasParentRect.rect.height);
        rect = getRect();
        rect.anchoredPosition = originalPosition;
        setTargetPosition();
        isExecuting = false;
        isFinished = false;
    }



    public void setCurrentPositionAsTargetPosition()
    {
        rect = getRect();
        targetPoint = new Vector2();
        targetPoint = rect.anchoredPosition;
    }

}
