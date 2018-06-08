using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float HealthPoints;
    public GameObject ExplosionParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" || collision.tag == "EnemyBullet")
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
            Instantiate(ExplosionParticle, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
