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
    public GameObject Explosion;
    public int ExplosionTimes;
    private int ExplodedTimes;
    public GameObject VictoryScreen;
    private bool EndAnimationHasStarted;

	// Use this for initialization
	void Start () {
        BossStage = 1;
        ExplodedTimes = 0;
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
        if(GetComponent<EnemyHealth>().HealthPoints <= 0)
        { if (EndAnimationHasStarted == false)
            {
                EndAnimationHasStarted = true;
                foreach (TurretMissileInstantiate item in GetComponentsInChildren<TurretMissileInstantiate>())
                {
                    item.enabled = false;
                }
                StartCoroutine(BossExplosion());
            }
        }
	}


    void InstantiateExplosion()
    {
        Instantiate(Explosion, new Vector3(Random.Range(gameObject.transform.position.x - 5, gameObject.transform.position.x + 5), Random.Range(gameObject.transform.position.y - 5, gameObject.transform.position.y + 5), -1f), Quaternion.Euler(0,180,0));
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

    IEnumerator BossExplosion()
    {
        print("Boss exploded!");
        while (ExplodedTimes < ExplosionTimes)
        {
            InstantiateExplosion();
            yield return new WaitForSeconds(1);
            ExplodedTimes++;
        }
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        Player.GetComponent<PlayerMovement>().enabled = false;
        foreach (AmmusInstantiate item in GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<AmmusInstantiate>())
        {
            item.enabled = false;
        }
        if (Player.GetComponent<PlayerHealth>().playerHealth != 0)
        {
            Instantiate(VictoryScreen, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(item);
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Destroy(item);
        }

    }
}
