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

public class ElasticSpawnFromSide : GUIEffect
{



    public Vector3 startPoint;

    public float elasticPower;

    public Vector3 pointToReachWhenResistanceEqualPower;

    float distanceToCover;

    public Vector2 finalPosition;

    public float returningPower;

    void Awake()
    {
        

    }

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(effect());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Initialize()
    {
        base.Initialize();
        rect.anchoredPosition = startPoint;
        distanceToCover = Vector3.Distance(rect.anchoredPosition, pointToReachWhenResistanceEqualPower);
    }

    public override IEnumerator startEffect()
    {
        yield return base.startEffect();
    }




    public override IEnumerator effect()
    {

        float newDistanceToCover = Vector3.Distance(rect.anchoredPosition, pointToReachWhenResistanceEqualPower);
        float newElasticPower = (elasticPower * newDistanceToCover) / distanceToCover;

        while (Mathf.Round(newElasticPower) > ((elasticPower/100)*20 ))
        {
            newDistanceToCover = Vector3.Distance(rect.anchoredPosition, pointToReachWhenResistanceEqualPower);
            newElasticPower = (elasticPower * newDistanceToCover) / distanceToCover;
            rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition, pointToReachWhenResistanceEqualPower, newElasticPower*Time.deltaTime*25);
            // rect.anchoredPosition = new Vector3(rect.anchoredPosition.x, rect.anchoredPosition.y - newElasticPower);
            yield return new WaitForEndOfFrame();
        }


        newElasticPower = 0;

        bool reached = false;

        while (!reached)
        {
            newElasticPower +=  returningPower* Time.deltaTime;
            rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition, finalPosition, newElasticPower);


            if(rect.anchoredPosition == finalPosition) { reached = true; }

            yield return null;
        }
    }


    
}
