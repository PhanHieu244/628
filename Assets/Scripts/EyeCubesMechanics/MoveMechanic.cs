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
using UnityEngine.EventSystems;

public class MoveMechanic : MonoBehaviour {
    public Side side;
    float movePower = 20f;
    public enum Side {
    left,right}
    public Rigidbody rigid;
    Vector3 startposition;
 

	// Update is called once per frame
	void Update () {

        if (StateManager.instance.playState != StateManager.PlayState.ingame) { return; }

        if (EventSystem.current.IsPointerOverGameObject()) { return; }


        if (side == Side.left) {

            float xl = -2.65f;
            float xr = -0.63f;

            if (!ClickControl.instance.isLeftScreenTouched())
            {
             
                Vector3 target = transform.localPosition;
                target.x = xr;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, movePower * Time.deltaTime);
              
            }
            else {
               
                Vector3 target = transform.localPosition;
                target.x = xl;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, movePower * Time.deltaTime);

            }
        }
        if (side == Side.right)
        {
            float xl = 0.63f;
            float xr = 2.65f;

            if (!ClickControl.instance.isRightScreenTouched())
            {
                Vector3 target = transform.localPosition;
                target.x = xl;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, movePower * Time.deltaTime);

            }
            else {
                Vector3 target = transform.localPosition;
                target.x = xr;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, movePower * Time.deltaTime);

            }
        }

    }

    public void ResetEye() {
        transform.position = startposition;
        rigid.velocity = Vector3.zero;
    }
}
