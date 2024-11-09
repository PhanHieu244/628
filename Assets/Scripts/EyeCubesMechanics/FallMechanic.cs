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

public class FallMechanic : MonoBehaviour {
    public Rigidbody rigid;
    float speedMultiplier = 2f;
	// Update is called once per frame
	void FixedUpdate () {
        if (StateManager.instance.playState != StateManager.PlayState.ingame)
        {
            rigid.velocity = Vector3.zero; return;
        }

        Vector3 currentPos = transform.localPosition;
        Vector3 targetPos = currentPos;
        currentPos.z = 0;
        transform.localPosition = currentPos;
        targetPos.y = 0f;
        float dist = currentPos.y - targetPos.y;



        rigid.velocity += (Vector3.down * dist)* speedMultiplier;
        

	}
}
