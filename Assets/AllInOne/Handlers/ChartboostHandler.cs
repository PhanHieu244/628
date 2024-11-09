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


public class ChartboostHandler : MonoBehaviour {
	string app_ID;
	string app_Signature;

	// Use this for initialization
	public void Initialize(string appId, string appSignature, GameObject mainController){
		app_ID = appId;
		app_Signature = appSignature;
		CBSettings settings = new CBSettings ();


		#if UNITY_ANDROID
			settings.SetAndroidAppId (app_ID);
			settings.SetAndroidAppSecret (app_Signature);

		#endif

		#if UNITY_IOS
			settings.SetIOSAppId (app_ID);
			settings.SetIOSAppSecret (app_Signature);
		#endif



	

		mainController.AddComponent<Chartboost> ();

		Chartboost.cacheInterstitial (CBLocation.Default);

	}

	public void ShowInterstitial(){
		Chartboost.showInterstitial (CBLocation.Default);
		// caching is useless because Chartboost.setAutoCacheAds (); is true by default

	}


}
