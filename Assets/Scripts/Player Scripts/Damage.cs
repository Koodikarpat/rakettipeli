using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    private Levels LevelScript;
    private GameOver GameOverScript;
    private bool IsInvincible;
    public float InvincibilityTime; //Kuinka pitkä näkymättömyysanimaatio.
    public float InvincibilitySpeed; //Kuinka nopeasti näkymättömyysanimaatio pyörii.
    private float LoopedTime;
    public float MaxInvincibilityLoopTime; //Montako kertaa näkymättömyysanimaatio looppaa.
    private List<GameObject> ActiveBarrels = new List<GameObject>();
    private Transform Fire;

    private void Awake()
    {
        LevelScript = GetComponent<Levels>();
        GameOverScript = GetComponent<GameOver>();
        Fire = gameObject.transform.Find("iso liekki");
    }
    void Start()
    {
        SetBarrels();
    }

    void SetBarrels() //Pelin alussa levelin 1 barrelit asetetaan aktiivisiksi.
    {
        foreach (GameObject item in LevelScript.Level1Barrels)
        {
            ActiveBarrels.Add(item);
        }
    }

    IEnumerator Invincibility() //Näkymättömyys, joka aktivoituu, kun pelaaja ottaa vahinkoa. Jos on näkymätön, pelaaja ei voi ottaa vahinkoa ja hän menee vihollisten läpi.
    {
        LoopedTime = 0;
        IsInvincible = true;
        gameObject.tag = "Untagged";
        gameObject.layer = 10;
        Debug.Log(gameObject.layer);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Fire.GetComponent<SpriteRenderer>().enabled = false;
        foreach (GameObject item in ActiveBarrels)
        {
            item.SetActive(false);
        }
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Fire.GetComponent<SpriteRenderer>().enabled = true;
        foreach (GameObject item in ActiveBarrels)
        {
            item.SetActive(true);
        }
        while (LoopedTime <= MaxInvincibilityLoopTime - 1)
        {
            yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Fire.GetComponent<SpriteRenderer>().enabled = false;
            foreach (GameObject item in ActiveBarrels)
            {
                item.SetActive(false);
            }
            yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Fire.GetComponent<SpriteRenderer>().enabled = true;
            foreach (GameObject item in ActiveBarrels)
            {
                item.SetActive(true);
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
            if (IsInvincible == false)
            {
                Debug.Log("Met an enemy");

                if (LevelScript.level == 3) //Laskeminen levelistä 3 leveliin 2.
                {
                    LevelScript.level--;
                    foreach (GameObject item in LevelScript.Level1Barrels)
                    {
                        item.SetActive(false);
                    }
                    SetActiveBarrels();
                    StartCoroutine(Invincibility()); //Funktio, joka aloittaa näkymättömyysanimaation.
                    return;
                }

                if (LevelScript.level == 2) //Laskeminen levelistä 2 leveliin 1.
                {
                    LevelScript.level--;
                    foreach (GameObject item in LevelScript.Level2Barrels)
                    {
                        item.SetActive(false);
                    }
                    foreach (GameObject item in LevelScript.Level1Barrels)
                    {
                        item.SetActive(true);
                    }
                    SetActiveBarrels();
                    StartCoroutine(Invincibility());
                    return;
                }


                if (LevelScript.level == 1) //Jos pelaaja ottaa vahinkoa ollessaan levelillä 1, hän kuolee, ja pyöritetään animaatiota Game Over-scriptistä.
                {
                    GameOverScript.GameOverAnimation();
                }
                SetActiveBarrels();
                StartCoroutine(Invincibility());

            }
        }
    }

    void SetActiveBarrels() //Määrittää barrelit, joita pelaaja käyttää. Tarvitaan, jotta näkymättömyysanimaatio toimisi oikein.
    {
        if (LevelScript.level == 3)
        {
            ActiveBarrels.Clear();
            foreach (GameObject item in LevelScript.Level1Barrels)
            {
                ActiveBarrels.Add(item);
            }

            foreach (GameObject item in LevelScript.Level2Barrels)
            {
                ActiveBarrels.Add(item);
            }
        }

        if (LevelScript.level == 2)
        {
            ActiveBarrels.Clear();

            foreach (GameObject item in LevelScript.Level2Barrels)
            {
                ActiveBarrels.Add(item);
            }
        }

        if (LevelScript.level == 1)
        {
            ActiveBarrels.Clear();

            foreach (GameObject item in LevelScript.Level1Barrels)
            {
                ActiveBarrels.Add(item);
            }
        }
        Debug.Log("Set active barrels");
    }
}
