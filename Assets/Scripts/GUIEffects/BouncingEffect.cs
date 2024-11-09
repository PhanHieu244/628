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

public class BouncingEffect : MonoBehaviour {

    float minReachPoint = 0;
    float maxReachPoint = 1;
    float targetReachPoint = 0.85f;
    float bounceValue = 0;
    float startPos = 390;
    float endPos = -500;
    float bouncingOffset = 1.8f;
    float returningOffset;
    Vector3 rectPos;
    public RectTransform rectTransform;
	// Use this for initialization
	void Start () {
        returningOffset = bouncingOffset-0.3f;
        rectPos = rectTransform.anchoredPosition;
        rectPos.y = startPos;
        UpdateRectPosition();

        StartCoroutine(bouncingValue());



    }
	
	// Update is called once per frame
	void Update () {

    }


    void UpdateRectPosition() {
        rectPos.y = Mathf.Lerp(startPos, endPos, bounceValue);
        rectTransform.anchoredPosition = rectPos;

    }


    public IEnumerator bouncingValue() {

        float bouncing= bouncingOffset;
        bool reachBottom = false;
        bool exit =false;
        while (!reachBottom && !exit) {
            UpdateRectPosition();

            yield return new WaitForEndOfFrame();


            bounceValue += Time.deltaTime*bouncing;
            bouncing -= Time.deltaTime * bouncingOffset;

            if (bounceValue > 0.91f && !reachBottom)
            {
                
                reachBottom = true;

            }


            while (reachBottom && !exit) {
                UpdateRectPosition();

                yield return new WaitForEndOfFrame();


                bounceValue += Time.deltaTime * bouncing;

                bouncing -= Time.deltaTime * returningOffset;

                if (bounceValue < targetReachPoint) {
                    exit = true;
                    yield return null;
                }

            }
      

      
           

        }

        





    }

}
