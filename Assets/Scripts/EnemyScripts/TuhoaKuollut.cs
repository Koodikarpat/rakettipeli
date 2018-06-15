using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuhoaKuollut : MonoBehaviour {

    EnemyHealth enemyHealth;
    bool onkoKuollut;
    public bool IsBoss;
    public GameObject VictoryScreen;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update () {

        onkoKuollut = enemyHealth.onkoKuollut;

        if (onkoKuollut == true)
        {   
            /* if (IsBoss==true)
            {
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("EnemyBullet"))
                {
                    Destroy(item);
                }
                foreach (GameObject item in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Destroy(item);
                }
                Instantiate(VictoryScreen, gameObject.transform.position, Quaternion.identity);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<AmmusInstantiate>();
                foreach (AmmusInstantiate item in GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<AmmusInstantiate>())
                {
                    item.GetComponent<AmmusInstantiate>().enabled = false;
                }
            }*/
            //Destroy(gameObject);
        }
	}
}
