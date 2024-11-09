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


public class MovingEyeEffect : MonoBehaviour {
    float changePositionRateo = 0.75f;
    float movingSpeed = 1;
    float radius = 0.115f;

    Vector3 startLookPosition;
    Vector3 targetPosition;

    public Eye eye;
    public enum Eye {
        eyeLeft,eyeRight
    }


    void Start() {
        startLookPosition = transform.localPosition;
        StartCoroutine(changePositionRoutine());
    }

    IEnumerator changePositionRoutine() {
        while (true) {
            yield return new WaitForSeconds(changePositionRateo);
            ChangeEyePosition();
        }

    }

    void Update() {

        if (!ClickControl.instance.isLeftScreenTouched() && eye == Eye.eyeLeft) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startLookPosition, movingSpeed * Time.deltaTime);

            return;
        }

        if (!ClickControl.instance.isRightScreenTouched() && eye == Eye.eyeRight)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startLookPosition, movingSpeed * Time.deltaTime);

            return;
        }
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, movingSpeed * Time.deltaTime);
        
    }

    void ChangeEyePosition() {
        Vector3 randomCircle = Random.insideUnitSphere;
        randomCircle.z = 0;
        randomCircle.Normalize();
       targetPosition= Vector3.zero + randomCircle*radius;

    }


}
