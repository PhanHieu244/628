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

public class SpawnFromSide : GUIEffect
{
    public enum Side { top, bottom, left, right };
    public Side side;

    public float animationVelocity;
    public float afterMaxPointReachedAnimationVelocity;
    public Vector2 targetPoint;


    Vector2 maxTargetPoint;
    public float maxReachOffset;
    bool maxPointReached;

    public RectTransform canvasParentRect;
    public Vector2 parentCanvasSize;

    // Use this for initialization
    void Start()
    {
        base.Start();
        setCurrentPositionAsTargetPosition();
        reset();
    }

    // Update is called once per frame
   public override void EffectUpdate()
    {
        if (!maxPointReached)
        {
            rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition, maxTargetPoint, animationVelocity * Time.deltaTime);
            if (rect.anchoredPosition == maxTargetPoint)
            {
                maxPointReached = true;
            }
        }
        else {
            rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition, targetPoint, afterMaxPointReachedAnimationVelocity * Time.deltaTime);
            if (rect.anchoredPosition == targetPoint)
            {
                isExecuting = false;
                isFinished = true;
            }
        }
    }

    public void setOffScreen()
    {
        switch (side)
        {
            case Side.bottom:
                rect.localPosition = new Vector2(targetPoint.x, -parentCanvasSize.y / 2 - rect.rect.height / 2);
                maxTargetPoint.y += maxReachOffset;
                break;
            case Side.top:
                rect.localPosition = new Vector2(targetPoint.x, parentCanvasSize.y / 2 + rect.rect.height / 2);
                maxTargetPoint.y -= maxReachOffset;
                break;
            case Side.right:
                rect.localPosition = new Vector2(parentCanvasSize.x / 2 + rect.rect.width / 2, targetPoint.y);
                maxTargetPoint.x -= maxReachOffset;
                break;
            case Side.left:
                rect.localPosition = new Vector2(-parentCanvasSize.x / 2 - rect.rect.width / 2, targetPoint.y);
                maxTargetPoint.x += maxReachOffset;
                break;
        }
    }
    public override IEnumerator startEffect()
    {
        maxTargetPoint = targetPoint;
        setOffScreen();     
        isExecuting = true;
        maxPointReached = false;
        isFinished = false;
        yield return null;
    }


    public override void reset()
    {
        parentCanvasSize = new Vector2(canvasParentRect.rect.width, canvasParentRect.rect.height);
        rect = getRect();
        setOffScreen();
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
