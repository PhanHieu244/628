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

public class PauseGUI : MonoBehaviour {

    public Button soundButton;
    public Sprite soundEnabledImage;
    public Sprite soundDisabledImage;

    public void OnCloseButtonClick()
    {
        Deactivate();
    }

    public void Activate()
    {
        StateManager.instance.playState = StateManager.PlayState.paused;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        Time.timeScale = 1;
        StateManager.instance.playState = StateManager.PlayState.ingame;

        gameObject.SetActive(false);
    }

    public void onHomeButtonClick()
    {
        SoundsManager.instance.PlayMenuButtonSound();

        GUIManager.instance.ShowMainMenuGUI();
        GameManager.instance.StopAllCoroutines();
        InGameGUI.instance.gameObject.SetActive(false);
        Deactivate();
        Application.LoadLevel(Application.loadedLevelName);
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


}
