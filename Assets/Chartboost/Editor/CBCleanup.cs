/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件由会员免费分享，如果商用，请务必联系原著购买授权！

daily assets update for try.

U should buy a license from author if u use it in your project!
*/

using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public class CBCleanup : AssetPostprocessor
{
	private static string[] filesToRemove = {
		"Editor/CBAndroidSetupUI.cs",
		"Plugins/Chartboost/CBBinding.cs",
		"Plugins/Chartboost/CBJSON.cs",
		"Plugins/Chartboost/CBManager.cs",
		"Plugins/Chartboost/demo/CBEventListener.cs",
		"Plugins/Chartboost/demo/CBUIManager.cs",
		"Plugins/Chartboost/demo/CBTestScene.unity"
	};
	
	public static void Clean()
	{
		foreach(string fileName in filesToRemove) {
			if(File.Exists(System.IO.Path.Combine(Application.dataPath, fileName))) {
				AssetDatabase.DeleteAsset(System.IO.Path.Combine("Assets", fileName));
				Debug.Log("Removed legacy Chartboost file: " + fileName);
			}
		}

		AssetDatabase.Refresh();
	}
}
