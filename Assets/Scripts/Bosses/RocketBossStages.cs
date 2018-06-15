using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBossStages : MonoBehaviour {

    private int BossStage;
    public int Stage2Health;
    private GameObject Camera;
    private GameObject Player;
    public Transform[] StageTwoEnemyLocations;
    public GameObject StageTwoEnemy;

	// Use this for initialization
	void Start () {
        BossStage = 1;
	}
	
	void Update () {
		if (GetComponent<EnemyHealth>().HealthPoints <= Stage2Health)
        {
            if (BossStage == 1)
            {
                BossStage++;
                StartCoroutine(StartStageTwo());
            }
        }
	}

    IEnumerator StartStageTwo()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Camera.GetComponent<CameraController>().enabled = false;
        Camera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 5);
        Camera.GetComponent<Camera>().orthographicSize = 40;
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerMovement>().enabled = false;
        GameObject.Find("RocketBoss/avaruusStageChange").GetComponent<SpriteRenderer>().enabled = true;
        foreach (AmmusInstantiate item in GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<AmmusInstantiate>())
        {
            item.enabled = false;
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Destroy(item);
        }
        foreach (TurretMissileInstantiate item in GetComponentsInChildren<TurretMissileInstantiate>())
        {
            item.enabled = false;
        }
        yield return new WaitForSeconds(1);
        foreach (Transform item in StageTwoEnemyLocations)
        {
            Instantiate(StageTwoEnemy, item.transform.position, item.transform.rotation);
        }
        yield return new WaitForSeconds(1);
        Camera.GetComponent<CameraController>().enabled = true;
        Camera.GetComponent<Camera>().orthographicSize = GameObject.FindGameObjectWithTag("BossActivation").GetComponent<BossActivate>().CameraSizeInBossBattle;
        Player.GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("RocketBoss/avaruusStageChange").GetComponent<SpriteRenderer>().enabled = false;
        foreach (AmmusInstantiate item in GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<AmmusInstantiate>())
        {
            item.enabled = true;
        }
        foreach (TurretMissileInstantiate item in GetComponentsInChildren<TurretMissileInstantiate>())
        {
            item.enabled = true;
        }

    }
}
