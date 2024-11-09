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

public class SoundsManager : MonoBehaviour
{
    public AudioSource Break;
    public AudioSource DiamondAudioSource;
    public AudioSource GameOverAudioSource;
    public AudioSource MenuButtonAudioSource;





    public static SoundsManager instance;

    bool cannotExecuteSound;
    float timeToBePaused = 0.1f;

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

    }


    public void PlayAudioSource(AudioSource audioSource)
    {

        audioSource.Play();

    }

    IEnumerator CanExecuteCountDown()
    {
        cannotExecuteSound = true;
        yield return new WaitForSeconds(timeToBePaused);
        cannotExecuteSound = false;
    }


 

   
    public void PlayBreakSound()
    {
        Break.Play();
    }

   
    public void PlayGameOverSound()
    {
        GameOverAudioSource.Play();
    }

    public void PlayDiamondSound()
    {
        DiamondAudioSource.Play();
    }

    public void PlayMenuButtonSound()
    {
        MenuButtonAudioSource.Play();
    }

}
