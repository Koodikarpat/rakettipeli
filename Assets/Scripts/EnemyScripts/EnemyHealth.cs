using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float HealthPoints;
    public GameObject ExplosionParticle;
    public bool onkoKuollut = false;
    public int MaxLoopTime;
    private int LoopedTime;
    public float InvincibilityTime;
    public bool BossHasStarted;

    private void Start()
    {
        LoopedTime = 0;
    }

    void UpdateHealthBar() //Tämä funktio päivittää healthbarin arvon, kun vihollinen ottaa vahinkoa. Tätä käytetään ainoastaan bosseissa.
    {
        if (GetComponent<BossHealthBar>() != null)
        {
            GetComponent<BossHealthBar>().InstantiatedHealthBarCanvas.transform.Find("HealthSlider").GetComponent<Slider>().value = GetComponent<EnemyHealth>().HealthPoints;
        }
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
    void DestroyEnemy()
    {
        print("Destroyed enemy");
        if (GetComponent<BossHealthBar>() != null)
        {
            Destroy(GetComponent<BossHealthBar>().InstantiatedHealthBarCanvas);
        }
        Instantiate(ExplosionParticle, gameObject.transform.position, Quaternion.identity);
        onkoKuollut = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            HealthPoints--;
            if (HealthPoints <= 0)
            {
                DestroyEnemy();
            }
            UpdateHealthBar();
            StartCoroutine(DamageFlash());

            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            HealthPoints--;

            UpdateHealthBar();
            if (HealthPoints <= 0)
            {
                DestroyEnemy();
            }
            StartCoroutine(DamageFlash());
    }

        
    }
}
