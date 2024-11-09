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

public class ColorManager : MonoBehaviour {
    public Color[] colorsList;

    public Material firstMaterial, secondMaterial;
    Color targetcolor1, targetcolor2;
     float secondsToChangeColor = 15;
    void Start() {
        if (colorsList.Length < 2)
        {
            Debug.LogError("The color list in Color Manager has less than 2 values. Fix that!");
        }
        else {
            ChooseRandomColor();
            ForceColorImmediatly();
            StartCoroutine(ChangeColorDuringTime());
        }
    }

    void Update() {
        firstMaterial.color = Color.Lerp(firstMaterial.color, targetcolor1, 1 * Time.deltaTime);
        secondMaterial.color = Color.Lerp(secondMaterial.color, targetcolor2, 1 * Time.deltaTime);

    }

    void ForceColorImmediatly() {
        firstMaterial.color = targetcolor1;
        secondMaterial.color = targetcolor2;
        

    }

    IEnumerator ChangeColorDuringTime() {
        while (true)
        {
            yield return new WaitForSeconds(secondsToChangeColor);
            ChooseRandomColor();
        }
    }

    void ChooseRandomColor() {

        Color colorLeft = colorsList[Random.Range(0, colorsList.Length)];

        Color colorRight = colorLeft;
        while (colorRight == colorLeft) {
            colorRight = colorsList[Random.Range(0, colorsList.Length)];
        }


        targetcolor1 = colorLeft;
        targetcolor2 = colorRight;




    }
	

}
