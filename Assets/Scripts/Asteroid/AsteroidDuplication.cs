using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDuplication : MonoBehaviour {

    EnemyHealth enemyHealth;

    public Transform sijainti;
    public Rigidbody2D smallerAsteroid;

    bool onkoKuollut;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update () {

        onkoKuollut = enemyHealth.onkoKuollut;

        if (onkoKuollut == true)
        {
            Instantiate(smallerAsteroid, sijainti.position, Quaternion.identity);
            Instantiate(smallerAsteroid, sijainti.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
