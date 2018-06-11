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

    private void Awake()
    {
        healthScript = GetComponent<PlayerHealth>();
        GameOverScript = GetComponent<GameOver>();
        Fire = gameObject.transform.Find("iso liekki");
    }
    void Start()
    {
        RocketChildren = GetComponentsInChildren<SpriteRenderer>();
    }

    public IEnumerator Invincibility() //Näkymättömyys, joka aktivoituu, kun pelaaja ottaa vahinkoa. Jos on näkymätön, pelaaja ei voi ottaa vahinkoa ja hän menee vihollisten läpi.
    {
        LoopedTime = 0;
        IsInvincible = true;
        gameObject.tag = "Untagged";
        gameObject.layer = 10;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        foreach (SpriteRenderer item in RocketChildren)
        {
            item.enabled=false;
        }
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
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
        gameObject.tag = "Player";
        gameObject.layer = 9;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag== "EnemyBullet") //Jos pelaaja törmää viholliseen, hän ottaa vahinkoa.
        {
            if (healthScript.playerHealth > 1)
            {
                if (IsInvincible == false)
                {
                    healthScript.playerHealth--;
                    StartCoroutine(Invincibility());
                    return;
                }
            }

            if (healthScript.playerHealth == 1) //Jos pelaaja ottaa vahinkoa ollessaan levelillä 1, hän kuolee, ja pyöritetään animaatiota Game Over-scriptistä.
            {
                GameOverScript.GameOverAnimation();
            }
        }
    }
}
