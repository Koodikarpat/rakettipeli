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

    private void Start()
    {
        LoopedTime = 0;
    }

    IEnumerator  DamageFlash()
    {
        while (LoopedTime < MaxLoopTime) //Jos vihollinen ottaa damagea, hän vilkkuu lyhyen ajan.
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(InvincibilityTime);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(InvincibilityTime);
            LoopedTime++;
        }
        LoopedTime = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" || collision.tag == "EnemyBullet")
        {
            HealthPoints--;
            Destroy(collision.gameObject);
            StartCoroutine(DamageFlash());
        }

        if (collision.tag == "Player")
        {
            HealthPoints--;
            StartCoroutine(DamageFlash());
        }

        if (HealthPoints <= 0)
        {
            Instantiate(ExplosionParticle, gameObject.transform.position, Quaternion.identity);
            onkoKuollut = true;
        }
    }
}
