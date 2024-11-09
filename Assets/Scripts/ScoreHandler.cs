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

public class ScoreHandler : MonoBehaviour
{

    public int score;
    public int secondaryScore;
    public int lifetimeScore;
    public int highScore;
    public int specialPoints;
    public int numberOfGames;


    string highScorePlayerPrefsName = "HIGHSCORE";
    string specialPointsPlayerPrefsName = "SPECIALPOINTS";
    string numberOfGamesPlayerPrefsName = "NUMBEROFGAMES";
    string lifeTimeScorePlayerPrefsName = "LIFETIMESCORE";


    public static ScoreHandler instance;
    void Awake()
    {
        instance = this;
        loadHighScoreFromPrefs();
        loadLifeTimeScoreFromPrefs();
        loadSpecialPointsFromPlayerPrefs();
        loadNumberOfGamesFromPlayerPrefs();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void increaseSpecialPoints(int valueToAdd)
    {
        specialPoints+= valueToAdd;
        saveSpecialPointsToPlayerPrefs();
    }

    public void increaseScore(int valueToAdd)
    {
        score += valueToAdd;
        lifetimeScore += valueToAdd;

        saveLifeTimeScoreToPrefs();

        if (score > highScore)
        {
            highScore = score;
            saveHighScoreToPrefs();
        }

    }


    public void increaseSecondaryScore(int valueToAdd)
    {
        secondaryScore += valueToAdd;
    }

    public void incrementNumberOfGames()
    {
        numberOfGames++;
        PlayerPrefs.SetInt(numberOfGamesPlayerPrefsName, numberOfGames);
    }

    public void loadNumberOfGamesFromPlayerPrefs()
    {
        numberOfGames = PlayerPrefs.GetInt(numberOfGamesPlayerPrefsName,0);
    }

    public void removeSpecialPoints(int specialPointsToRemove)
    {
        specialPoints -= specialPointsToRemove;
    }

    void saveSpecialPointsToPlayerPrefs()
    {
        PlayerPrefs.SetInt(specialPointsPlayerPrefsName, specialPoints);
    }

    void loadSpecialPointsFromPlayerPrefs()
    {
        specialPoints = PlayerPrefs.GetInt(specialPointsPlayerPrefsName, 0);
    }

    void saveHighScoreToPrefs()
    {
        PlayerPrefs.SetInt(highScorePlayerPrefsName, highScore);
    }

    void saveLifeTimeScoreToPrefs()
    {
        PlayerPrefs.SetInt(lifeTimeScorePlayerPrefsName, lifetimeScore);
    }

    void loadLifeTimeScoreFromPrefs()
    {
        lifetimeScore = PlayerPrefs.GetInt(lifeTimeScorePlayerPrefsName, 0);
    }

    void loadHighScoreFromPrefs()
    {
        highScore = PlayerPrefs.GetInt(highScorePlayerPrefsName, 0);
    }

    public void reset()
    {
        score = 0;
        secondaryScore = 0;
    }


}
