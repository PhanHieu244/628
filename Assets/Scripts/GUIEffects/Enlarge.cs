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

public class Enlarge : GUIEffect {


    Vector3 finalSize;
    Rect elementRect;

    public float enlargmentVelocity;


    public float maxDilatationOffset;
    protected bool reachedMaxDilatation;


    void Awake()
    {
        finalSize = this.transform.localScale;
    }

	// Use this for initialization
	void Start () {       

    }
	
	// Update is called once per frame
	void Update () {

        if (isExecuting)
        {
            if (!reachedMaxDilatation)
            {
                Vector3 scaleWhenMaxDilatated = finalSize;
                scaleWhenMaxDilatated.x += maxDilatationOffset;
                scaleWhenMaxDilatated.y += maxDilatationOffset;

                transform.localScale = Vector2.MoveTowards(transform.localScale, scaleWhenMaxDilatated, enlargmentVelocity * Time.deltaTime);

                if(transform.localScale.x == scaleWhenMaxDilatated.x)
                {
                    reachedMaxDilatation = true;
                }
            }
            else
            {
                transform.localScale = Vector2.MoveTowards(transform.localScale, finalSize, enlargmentVelocity * Time.deltaTime);

                if(transform.localScale.x == finalSize.x)
                {
                    isExecuting = false;
                    isFinished = true;
                }
            }
        }
	
	}

    void OnEnable()
    {
        base.Start();
        
        transform.localScale = new Vector2(0, 0);
        transform.localScale = new Vector2(0, 0);
    }


    public override IEnumerator startEffect()
    {
        transform.localScale = new Vector2(0, 0);
        reachedMaxDilatation = false;
        isFinished = false;
        isExecuting = true;
        yield return null;
    }


}
