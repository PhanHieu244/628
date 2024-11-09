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

public class BreakParticleSpawner : MonoBehaviour {
    public GameObject particleLeft, particleRight;
    public static BreakParticleSpawner instance;

    void Awake() { instance = this; }
	// Use this for initialization
	
    public void SpawnParticle (Vector3 spawnPosition)
    {
        float posx = spawnPosition.x;
        if (posx <= 0) { Spawn(spawnPosition,particleLeft); } else { Spawn(spawnPosition,particleRight); }

    }

    void Spawn(Vector3 pos, GameObject obj) {
        Vector3 spawnPos = pos;
        spawnPos.z = obj.transform.position.z;
        GameObject newParticle = (GameObject)Instantiate(obj, spawnPos, obj.transform.rotation);
    }

}
