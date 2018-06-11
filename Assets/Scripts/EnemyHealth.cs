using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float HealthPoints;
    public GameObject ExplosionParticle;
    public bool onkoKuollut = false;
    public int MaxLoopTime;
    private int LoopedTime;
    public float InvincibilityTime;

    IEnumerator  DamageFlash()
    {
        while (LoopedTime < MaxLoopTime)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(InvincibilityTime);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(InvincibilityTime);
            LoopedTime++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" || collision.tag == "EnemyBullet")
        {
            HealthPoints--;
            Destroy(collision.gameObject);
            DamageFlash();

            
        }

        if (collision.tag == "Player")
        {
            HealthPoints--;
            DamageFlash();
        }

        if (HealthPoints <= 0)
        {
            Instantiate(ExplosionParticle, gameObject.transform.position, Quaternion.identity);
            onkoKuollut = true;
        }
    }
}
