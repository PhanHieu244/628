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
using System.Collections.Generic;
using UnityEngine.UI;
public class GUIElement : MonoBehaviour
{

    public float secondsToWaitToStart;


    public List<GUIEffect> spawnEffects;
    public List<GUIEffect> disappearEffects;


    public bool spawnStarted;


    protected float originalAlpha;
    protected CanvasRenderer canvasRenderer;


    // Use this for initialization
    void Awake()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();
        originalAlpha = canvasRenderer.GetAlpha();
    }



    void OnEnable()
    {

    }

    public void disappear()
    {
        if (disappearEffects.Count == 0) { canvasRenderer.SetAlpha(0); }
        foreach (GUIEffect effect in disappearEffects)
        {
            effect.startEffect();
        }
    }

    public IEnumerator spawn()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();

        yield return new WaitForSeconds(secondsToWaitToStart);

        foreach (GUIEffect effect in spawnEffects)
        {
            effect.Initialize();
            yield return StartCoroutine(effect.startEffect());


        }

    }


    void OnDisable()
    {
        foreach (GUIEffect effect in spawnEffects)
        {
            effect.reset();
        }
        foreach (GUIEffect effect in disappearEffects)
        {
            effect.reset();
        }
    }

}
