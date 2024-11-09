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

#if UNITY_ANDROID
#endif
using UnityEngine.SocialPlatforms;

#if UNITY_IOS
using UnityEngine.SocialPlatforms.GameCenter;
#endif


public class Leaderboard : MonoBehaviour
{

	public static Leaderboard instance;

	public string googlePlayLeaderboardID;
	public string gameCenterLeaderboardID;

	string leaderboardIdToUse;
	protected bool isLogged;

	void Awake ()
	{
		if (instance != null) {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		instance = this;

		initialize ();
		signIn ();
	}

	// Use this for initialization
	void Start ()
	{
     
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void signIn ()
	{
		// authenticate user:
		Social.localUser.Authenticate ((bool success) => {
			if (success) {
				isLogged = true;
			} else {
				isLogged = false;
			}
		});
	}

	public void reportScore (long score)
	{
		try {
			/*Social.ReportScore (score, leaderboardIdToUse, (bool success) => {

			});*/
		} catch {

		}
	}

	public void showLeaderboard ()
	{


#if UNITY_IOS
 GameCenterPlatform.ShowLeaderboardUI(leaderboardIdToUse,0);
#endif
	}

	void initialize ()
	{


#if UNITY_IOS
 leaderboardIdToUse = gameCenterLeaderboardID ;
#endif
	}

}

