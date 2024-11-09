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

public class GUICanvas : MonoBehaviour
{

    GUIElement[] guiElements;

    public bool isDeactivating;
    public float secondsToWaitBeforeDeactivating = 0;

    float elapsedSecondsSinceDeactivating;


    void Awake()
    {
        guiElements = GetComponentsInChildren<GUIElement>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        isDeactivating = false;
        disableAllDisappearEffects();
        spawnCanvasElements();        
    }

    public void activateCanvas()
    {
        isDeactivating = false;
        gameObject.SetActive(true);
        OnEnable();
    }


    public void deactivateCanvas()
    {
        StartCoroutine(deactivateCanvasCoroutine());
    }

    private IEnumerator deactivateCanvasCoroutine()
    {
        deactivateCanvasButtons();
        disableAllSpawnEffects();

        if (guiElements != null)
        {
            foreach (GUIElement element in guiElements)
            {
                element.disappear();
            }
        }

        yield return new WaitForSeconds(secondsToWaitBeforeDeactivating);
        this.gameObject.SetActive(false);
        yield return null;
    }

    void deactivateCanvasButtons()
    {
        Button[] canvasButtons = GetComponentsInChildren<Button>();
        foreach(Button button in canvasButtons)
        {
            button.interactable = false;
        }
    }

    void activateCanvasButtons()
    {
        Button[] canvasButtons = GetComponentsInChildren<Button>();
        foreach (Button button in canvasButtons)
        {
            button.interactable = true;
        }
    }

    void disableAllDisappearEffects()
    {
        foreach (GUIElement element in guiElements)
        {
            foreach (GUIEffect effect in element.disappearEffects)
            {
                effect.isExecuting = false;
            }
        }
    }

    void disableAllSpawnEffects()
    {
        if (guiElements != null)
        {
            foreach (GUIElement element in guiElements)
            {
                foreach (GUIEffect effect in element.spawnEffects)
                {
                    effect.isExecuting = false;
                }
            }
        }
    }

    void spawnCanvasElements()
    {
        activateCanvasButtons();
        foreach (GUIElement guiElement in guiElements)
        {
            StartCoroutine(guiElement.spawn());
        }
    }

}
