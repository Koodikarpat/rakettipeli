using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    private PlayerHealth healthScript;
    private GameOver GameOverScript;
    private bool IsInvincible;
    public float InvincibilityTime; //Kuinka pitkä näkymättömyysanimaatio.
    public float InvincibilitySpeed; //Kuinka nopeasti näkymättömyysanimaatio pyörii.
    private float LoopedTime;
    public float MaxInvincibilityLoopTime; //Montako kertaa näkymättömyysanimaatio looppaa.
    private Transform Fire;
    private Component[] RocketChildren;
    private int playerHealth;

    void GetRocketChildren()
    {
        RocketChildren = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Awake()
    {
        healthScript = GetComponent<PlayerHealth>();
        GameOverScript = GetComponent<GameOver>();
        Fire = gameObject.transform.Find("iso liekki");
    }
    void Start()
    {
        GetRocketChildren();
    }

    public IEnumerator Invincibility() //Näkymättömyys, joka aktivoituu, kun pelaaja ottaa vahinkoa. Jos on näkymätön, pelaaja ei voi ottaa vahinkoa ja hän menee vihollisten läpi.
    {
        GetRocketChildren();
        LoopedTime = 0;
        IsInvincible = true;
        gameObject.layer = 10;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        foreach (SpriteRenderer item in RocketChildren)
        {
            item.enabled=false;
        }
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //Fire.GetComponent<SpriteRenderer>().enabled = true;
        foreach (SpriteRenderer item in RocketChildren)
        {
            item.enabled = true;
        }
        while (LoopedTime <= MaxInvincibilityLoopTime - 1)
        {
            yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //Fire.GetComponent<SpriteRenderer>().enabled = false;
            foreach (SpriteRenderer item in RocketChildren)
            {
                item.enabled = false;
            }
            yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
            //Fire.GetComponent<SpriteRenderer>().enabled = true;
            foreach (SpriteRenderer item in RocketChildren)
            {
                item.enabled = true;
            }
            LoopedTime++;
        }
        IsInvincible = false;
        gameObject.layer = 9;
    }

    public void TakeDamage(int damage)
    {
        if (healthScript.playerHealth > 1)
        {
            if (IsInvincible == false)
            {
                healthScript.playerHealth -= damage;
                StartCoroutine(Invincibility());
                return;
            }
        }

        if (healthScript.playerHealth == 1) //Jos pelaaja ottaa vahinkoa ollessaan levelillä 1, hän kuolee, ja pyöritetään animaatiota Game Over-scriptistä.
        {
            GameOverScript.GameOverAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy" || collision.transform.tag== "EnemyBullet") //Jos pelaaja törmää viholliseen, hän ottaa vahinkoa.
        {
            TakeDamage(1);
        }
    }
}
