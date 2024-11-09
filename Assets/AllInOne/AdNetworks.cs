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
using ChartboostSDK;
using UnityEngine.Advertisements;

public class AdNetworks : MonoBehaviour
{
    AdmobHandler admobHandler;
    ChartboostHandler chartboostHandler;

    public bool InitializeNetworksOnStart = true;
    public int LoadInterstitialEveryXCalls = 1;
    static int interstitialCounter;
    public static AdNetworks instance;

    bool adsEnabled;

    public BannersNetwork bannerNetwork;
    public enum BannersNetwork
    {
        Admob, nothing
    }

    public InterstitialNetwork interstitialNetwork;
    public enum InterstitialNetwork
    {
        Admob, Chartboost, nothing
    }

    public BannersPosition bannersPosition;
    public enum BannersPosition
    {
        Bottom, Top, BottomLeft, BottomRight, TopLeft, TopRight
    }


    public string Admob_Banner_ID = "Your adMob Banner ID";
    public string Admob_Interstitial_ID = "Your adMob Interstitial ID";

    public string Chartboost_App_ID = "Your ChartBoost App ID";
    public string Chartboost_App_Signature = "Your ChartBoost App Signature";



    int caseSwitchInteger;





    // Use this for initialization
    void Awake()
    {


        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }



        DontDestroyOnLoad(this.gameObject);

        instance = this;
        adsEnabled = true;

        if (areAdsAlreadyRemoved())
        {
            disableAds();           
        }

        admobHandler = gameObject.AddComponent<AdmobHandler>();

        chartboostHandler = gameObject.AddComponent<ChartboostHandler>();

        if (InitializeNetworksOnStart)
        {
            InitializeNetworks();
        }




    }



    public void InitializeNetworks()
    {

        // Initialize for Banners

        switch (bannerNetwork)
        {
            case BannersNetwork.Admob:
                admobHandler.Initialize(Admob_Banner_ID, Admob_Interstitial_ID, false);
                break;
        }


        // Initialize for Interstitials

        switch (interstitialNetwork)
        {

            case InterstitialNetwork.Admob:
                admobHandler.Initialize(Admob_Banner_ID, Admob_Interstitial_ID, true);
                break;

            case InterstitialNetwork.Chartboost:
                chartboostHandler.Initialize(Chartboost_App_ID, Chartboost_App_Signature, this.gameObject);
                break;


        }


    }

    public void ShowBanner()
    {
        if (!adsEnabled)
        {
            return;
        }
        switch (bannerNetwork)
        {


            case BannersNetwork.Admob:
                admobHandler.ShowBanner(PositionBannerInteger());
                break;
        }

    }

    public void HideBanner()
    {

        switch (bannerNetwork)
        {
            case BannersNetwork.Admob:
                admobHandler.HideBanner();
                break;

        }
    }



    public void ShowInterstitial()
    {
        if (!adsEnabled)
        {
            return;
        }

        if (interstitialCounter > 1)
        {
            interstitialCounter--;

            return;
        }
        interstitialCounter = LoadInterstitialEveryXCalls;


        switch (interstitialNetwork)
        {

            case InterstitialNetwork.Admob:
                admobHandler.ShowInterstitial();
                break;
            case InterstitialNetwork.Chartboost:
                chartboostHandler.ShowInterstitial();
                break;

        }

    }





    //--------------------------------------------------------------------------------



    int PositionBannerInteger()
    {
        switch (bannersPosition)
        {
            case BannersPosition.Bottom:
                caseSwitchInteger = 1;
                break;
            case BannersPosition.Top:
                caseSwitchInteger = 2;
                break;
            case BannersPosition.BottomLeft:
                caseSwitchInteger = 3;
                break;
            case BannersPosition.BottomRight:
                caseSwitchInteger = 4;
                break;
            case BannersPosition.TopLeft:
                caseSwitchInteger = 5;
                break;
            case BannersPosition.TopRight:
                caseSwitchInteger = 6;
                break;

        }
        return caseSwitchInteger;


    }


    void OnDisable()
    {
        try {
            HideBanner();
            adsEnabled = false;
        }
        catch
        {

        }
    }

    public void disableAds()
    {
        gameObject.SetActive(false);
        saveToPlayerPrefs();
    }

    void saveToPlayerPrefs()
    {
        PlayerPrefs.SetInt("ADSREMOVED", 1);
    }

    bool areAdsAlreadyRemoved()
    {
        if (PlayerPrefs.GetInt("ADSREMOVED") == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
