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

public class ObstacleSpawner : MonoBehaviour {
    public GameObject[] obstacles;
    public GameObject point;
     float spawnRateoSeconds = 0.3f;

    public float littleProbability = 0;
    public float mediumProbability = 15;
    public float bigProbability = 40;
    public float maxProbability = 100;
    public float pointProbability = 10;
    bool currentRandomSide;
    public Transform leftInternal, leftExternal, rightInternal, rightExternal;


	// Use this for initialization
	void Start () {
        StartCoroutine(spawnRoutine());
	}
	

    IEnumerator spawnRoutine() {
        while (true) {
            yield return new WaitForSeconds(spawnRateoSeconds);
            if (StateManager.instance.playState==StateManager.PlayState.ingame)
            SpawnRandomObstacle();
        }

    }
    bool SideAlternate() {
        currentRandomSide = !currentRandomSide;
        return currentRandomSide;
    }


    void SpawnRandomObstacle() {

        Vector3 obstacleScale = obstacles[0].gameObject.transform.localScale;

        float randomObstacleSpawn = Random.Range(0, maxProbability);
        int randomSize = 1;
        if (randomObstacleSpawn >= littleProbability) randomSize = 1;
        if (randomObstacleSpawn >= mediumProbability) randomSize = 2;
        if (randomObstacleSpawn >= bigProbability) randomSize = 3;

        float randomX = randomSize * 0.66f; // offset for size
        
        obstacleScale.x = randomX;


        bool alternateSide = SideAlternate();


        //  int randomSide = Random.Range(0, 1 + 1); // 0 = left, 1 = right

        int randomSide = 0;
        if (alternateSide) randomSide = 1;

        int randomInternalExternal = Random.Range(0, 1 + 1); // 0 = internal, 1 =external

        Vector3 obstaclePosition = obstacles[randomSide].transform.position;


        if (randomSide == 0)
        {

            if (randomInternalExternal == 0)
            {
                obstaclePosition.x = leftInternal.position.x;
                obstaclePosition.x -= obstacleScale.x / 2;

            }
            else
            {
                obstaclePosition.x = leftExternal.position.x;
                obstaclePosition.x += obstacleScale.x / 2;
            }

        }
        if (randomSide == 1)
        {
            if (randomInternalExternal == 0)
            {
                obstaclePosition.x = rightInternal.position.x;
                obstaclePosition.x += obstacleScale.x / 2;

            }
            else
            {
                obstaclePosition.x = rightExternal.position.x;
                obstaclePosition.x -= obstacleScale.x / 2;
            }
        }

        obstacles[randomSide].transform.localScale = obstacleScale;
        GameObject newObjstacle = (GameObject)Instantiate(obstacles[randomSide], obstaclePosition, Quaternion.identity);

        if (HaveToSpawnPoint())
        {
            GameObject newPoint = (GameObject)Instantiate(point, point.transform.position, point.transform.rotation);
            Vector3 pointPosition = newPoint.transform.position;
            int randomDirection = Random.Range(0, 2);
            float randomDir = 0;
            if (randomDirection == 0) { randomDir = 1; } else { randomDir = -1.5f; }


            pointPosition.y = newObjstacle.transform.position.y+  (1* randomDir);
            pointPosition.x = newObjstacle.transform.position.x;
            newPoint.transform.position = pointPosition;
            newPoint.transform.parent = newObjstacle.transform;
        }
       
    }

    bool HaveToSpawnPoint() {
        int random = Random.Range(0,(int) maxProbability);
        if (random <= pointProbability + 1)
        {
            return true;
        }
        else {
            return false;
        }
    }





}
