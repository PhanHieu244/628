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

public class AdmobHandler : MonoBehaviour {
	


	public void Initialize(string banner_id,string interstitial_id,bool useInterstitial){
		/*if (AlreadyInitialized) {
			return;
		}

		Banner_AD_ID = banner_id;
		Interstitial_AD_ID = interstitial_id;

		if (useInterstitial) {
		
			PrecacheNextInterstitial();
		
			AlreadyInitialized = true;
		
		}*/



	}


	public void ShowBanner(int position){
		/*if (position==1)
			adpos = AdPosition.Bottom;
		if (position==2)
			adpos = AdPosition.Top;
		if (position==3)
			adpos = AdPosition.BottomLeft;
		if (position==4)
			adpos = AdPosition.BottomRight;
		if (position==5)
			adpos = AdPosition.TopLeft;
		if (position==6)
			adpos = AdPosition.TopRight;
	

		string adUnitId = Banner_AD_ID;



		if (bannerView == null) {
			// Create a 320x50 banner at the top of the screen.
			bannerView = new BannerView (adUnitId, AdSize.SmartBanner, adpos);
			// Create an empty ad request.
			AdRequest request = new AdRequest.Builder ().Build ();
			// Load the banner with the request.
			bannerView.LoadAd (request);
		} else {
			bannerView.Show();}
			*/


	}


	public void HideBanner(){
        /*try {
            bannerView.Hide();
        }
        catch
        {
            
        }*/
        	}

	public void ShowInterstitial(){

		/*interstitialADMOB.Show ();
		*/

		PrecacheNextInterstitial ();
	}


	private void PrecacheNextInterstitial(){
		/*interstitialADMOB = new InterstitialAd (Interstitial_AD_ID);
		AdRequest request = new AdRequest.Builder ().Build ();
		interstitialADMOB.LoadAd (request);*/
	}




}
