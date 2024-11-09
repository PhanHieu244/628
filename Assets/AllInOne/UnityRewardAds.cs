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
using UnityEngine.Advertisements;

public class UnityRewardAds : MonoBehaviour
{

    public int minCoinsToRewardOnVideoWatched = 75;
    public int maxCoinsToRewardOnVideoWatched = 100;

    public static UnityRewardAds instance;

    public string rewardVideoID;

    void Awake()
    {
        instance = this;
    }

    public void ShowRewardedAd(System.Action<ShowResult> callaBack)
    {
        /*if (Advertisement.IsReady(rewardVideoID))
        {
            var options = new ShowOptions { resultCallback = callaBack };
            Advertisement.Show(rewardVideoID, options);
        }*/
    }



    public int GetCoinsToRewardOnVideoWatched()
    {
        return Random.Range(minCoinsToRewardOnVideoWatched, maxCoinsToRewardOnVideoWatched);
    }




}
