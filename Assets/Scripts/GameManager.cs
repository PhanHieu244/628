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

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public enum GameState { menu, game, gameover, shop }
    public GameState gameState;
    public bool oneMoreChanceUsed = false;

    void Awake()
    {
        Application.targetFrameRate = 60;
        instance = this;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator GameOverCoroutine(float delay)
    {

        yield return new WaitForSeconds(delay);
        SoundsManager.instance.PlayGameOverSound();
        AdNetworks.instance.HideBanner();
        gameState = GameState.gameover;

        Leaderboard.instance.reportScore(ScoreHandler.instance.score);
        GUIManager.instance.ShowGameOverGUI();
        InGameGUI.instance.gameObject.SetActive(false);


    }


    public void GameOver(float delay)
    {
        StartCoroutine(GameOverCoroutine(delay));
    }

    public void StartGame()
    {
        ResetGame();
        ScoreHandler.instance.incrementNumberOfGames();
        GUIManager.instance.ShowInGameGUI();
        AdNetworks.instance.ShowBanner();
        StateManager.instance.playState = StateManager.PlayState.ingame;
        GUIManager.instance.tutorialGUI.ShowIfNeverAppeared();


    }

    public void ResetGame(bool resetScore = true, bool resetOneMoreChance = true)
    {
        if (resetOneMoreChance)
        {
            oneMoreChanceUsed = false;
        }



        if (resetScore)
        {
            ScoreHandler.instance.reset();
        }
    }


}
