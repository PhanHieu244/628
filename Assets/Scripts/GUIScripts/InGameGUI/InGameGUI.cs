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

public class InGameGUI : MonoBehaviour
{

    public static InGameGUI instance;
    public Text scoreText;
    public Text specialPointsText;
    


    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = ScoreHandler.instance.score.ToString();
        specialPointsText.text = ScoreHandler.instance.specialPoints.ToString();

    }


    public void OnTutorialButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();
        GUIManager.instance.ShowTutorialGUI();
    }

    public void OnPauseButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();
        GUIManager.instance.ShowPauseGUI();
    }


}
