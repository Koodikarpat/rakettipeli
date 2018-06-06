using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float HealthPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            HealthPoints--;
            Destroy(collision.gameObject);
            
        }

        if (collision.tag == "Player")
        {
            HealthPoints--;
        }

        if (HealthPoints <= 0)
        {
            Destroy(gameObject);
            Debug.Log("ded");
        }
    }
}
