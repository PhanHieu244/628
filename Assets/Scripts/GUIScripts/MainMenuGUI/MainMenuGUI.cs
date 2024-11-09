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

public class MainMenuGUI : MonoBehaviour {

    public static MainMenuGUI instance;

    public Text highscoreText;
    public Text gamesPlayedText;

    string originalHighScoreText;
    string originalGamesPlayedText;
    void Awake()
    {
        instance = this;
        originalHighScoreText = highscoreText.text;
        originalGamesPlayedText = gamesPlayedText.text;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        highscoreText.text = originalHighScoreText + ScoreHandler.instance.highScore;
        gamesPlayedText.text = originalGamesPlayedText + ScoreHandler.instance.numberOfGames;
    }

    public void OnShopButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        gameObject.SetActive(false);
        GUIManager.instance.ShowShopGUI();
    }

    public void OnPlayButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        GameManager.instance.StartGame();
        gameObject.SetActive(false);
    }

    public void OnRateButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        RateManager.instance.rateGame();
    }

}
