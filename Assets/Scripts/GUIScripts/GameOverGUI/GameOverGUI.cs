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
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameOverGUI : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    public Text diamondText;


    public Text coinText;

    public Button GetCoinButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "" + ScoreHandler.instance.score;
        highScoreText.text = "" + ScoreHandler.instance.highScore;
        diamondText.text = "" + ScoreHandler.instance.specialPoints;

	}


    public void OnGetCoinButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        UnityRewardAds.instance.ShowRewardedAd(HandleShowResult);
        GetCoinButton.interactable = false;
    }

    public void OnBallShopClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        Deactivate();
        GUIManager.instance.ShowShopGUI();
    }

    public void OnRemoveAdsButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();
        
    }

    public void OnRestorePurchaseButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();
        
    }

    public void OnLeaderboardButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        Leaderboard.instance.showLeaderboard();
    }

    public void OnShareButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        ShareManager.instance.share();
    }

    public void OnPlayButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();
        Application.LoadLevel(Application.loadedLevel);
        Deactivate();
        GUIManager.instance.ShowMainMenuGUI();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }


    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                ScoreHandler.instance.increaseSpecialPoints(UnityRewardAds.instance.GetCoinsToRewardOnVideoWatched());
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }


}
