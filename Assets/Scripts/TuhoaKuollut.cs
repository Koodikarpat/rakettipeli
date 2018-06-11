using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuhoaKuollut : MonoBehaviour {

    EnemyHealth enemyHealth;
    bool onkoKuollut;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update () {

        onkoKuollut = enemyHealth.onkoKuollut;

        if (onkoKuollut == true)
        {
            Destroy(gameObject);
        }
	}
}
