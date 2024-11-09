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

public class TutorialGUI : MonoBehaviour
{

    string tutorialShownPlayerPrefsString = "TUTORIALSHOWN";


    public Button soundButton;
    public Sprite soundEnabledImage;
    public Sprite soundDisabledImage;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCloseButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();
        Deactivate();
    }

    public void onHomeButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();
        GUIManager.instance.ShowMainMenuGUI();
        InGameGUI.instance.gameObject.SetActive(false);
        GameManager.instance.StopAllCoroutines();

        Application.LoadLevel(Application.loadedLevelName);
        Deactivate();
    }

    public void OnSoundButtonClick()
    {
        if (AudioListener.volume == 0)
        {
            soundButton.image.sprite = soundEnabledImage;
            AudioListener.volume = 1;
        }
        else
        {
            soundButton.image.sprite = soundDisabledImage;
            AudioListener.volume = 0;
        }
    }

    public void Activate()
    {
        PlayerPrefs.SetInt(tutorialShownPlayerPrefsString, 1);
        StateManager.instance.playState = StateManager.PlayState.paused;

        Time.timeScale = 0;

        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        StateManager.instance.playState = StateManager.PlayState.ingame;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public bool tutorialShown()
    {
        int getInt = PlayerPrefs.GetInt(tutorialShownPlayerPrefsString, 0);
        if (getInt == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ShowIfNeverAppeared()
    {
        if (!tutorialShown())
        {
            Activate();
        }
    }

}
