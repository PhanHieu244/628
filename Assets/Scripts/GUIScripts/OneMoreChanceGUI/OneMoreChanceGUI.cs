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
using UnityEngine.Advertisements;

public class OneMoreChanceGUI : MonoBehaviour {



    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Activate()
    {
        gameObject.SetActive(true);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void OnOneMoreChanceButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        UnityRewardAds.instance.ShowRewardedAd(HandleShowResult);
        Deactivate();
    }

    public void OnGameOverButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        Deactivate();
        GameManager.instance.oneMoreChanceUsed = true;
        GameManager.instance.GameOver(0);
    }


    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:

                GameManager.instance.gameState = GameManager.GameState.game;
                GameManager.instance.oneMoreChanceUsed = true;
                GameManager.instance.ResetGame(false,false);
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
          
                GameManager.instance.gameState = GameManager.GameState.game;
                GameManager.instance.oneMoreChanceUsed = true;
                GameManager.instance.ResetGame(false,false);
                break;
            case ShowResult.Failed:

                GameManager.instance.gameState = GameManager.GameState.game;
                GameManager.instance.oneMoreChanceUsed = true;
                GameManager.instance.ResetGame(false,false);
                break;
        }
    }

}
