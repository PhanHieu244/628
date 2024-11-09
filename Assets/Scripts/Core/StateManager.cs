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

public class StateManager : MonoBehaviour {
    public MoveMechanic leftEye, rightEye;
    public static StateManager instance;
    public PlayState playState;
    public enum PlayState {
        ingame,outgame,paused
    }
    void Awake() {
        instance = this;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            RefreshGame(); 
        }
    }


    public void RefreshGame() {
        playState = PlayState.ingame;
        leftEye.gameObject.SetActive(true);
        rightEye.gameObject.SetActive(true);

        leftEye.ResetEye();
        rightEye.ResetEye();
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (Obstacle obst in obstacles) {
            Destroy(obst.gameObject);
        }

    }



    public void LoseGame() {      
        playState = PlayState.outgame;
        GameManager.instance.GameOver(0.5f);
    }
}
