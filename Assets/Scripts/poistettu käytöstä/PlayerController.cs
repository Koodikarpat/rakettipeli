using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


//Pistettu käytöstä. ÄLÄ KÄYTÄ MIHINKÄÄN!!! 

public class PlayerController : MonoBehaviour
{

    bool Move;
    private Rigidbody2D rb2d;
    public float thrust; //Raketin nopeus.
    public float rotationspeed; //Raketin kääntönopeus.
    //public GameObject Fire;
    public float level; //Pelaajan leveli. Nousee, kun nappaa powerupin.
    public GameObject[] Level1Barrels; //Barrelit, joita käytetään levelissä 1.
    public GameObject[] Level2Barrels; //Barrelit, joita käytetään levelissä 2.
    public GameObject ExplosionSprite; //Sprite, joka näkyy pelaajan kuoltaessa.
    public float InvincibilityTime; //Aika, jolloin pelaaja on näkymätön damagen ottamisen jälkeen.
    public float InvincibilitySpeed; //Nopeus, jolla raketti "vilkkuu" oltaessaan näkymättömässä tilanteessa.
    private bool IsInvincible; //Jos pelaaja on näkymätön, viholliset eivät voi tehdä vahinkoa.
    public Canvas Canvas;
    private List<GameObject> ActiveBarrels = new List<GameObject>();
    private float LoopedTime = 0;
    public float MaxInvincibilityLoopTime;
    bool combatMode = false;

    void SetBarrels()
    {
        foreach (GameObject item in Level1Barrels)
        {
            ActiveBarrels.Add(item);
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Fire.SetActive(false);
        level = 1;
        //Canvas.gameObject.GetComponent<Animator>().enabled = false;
        Canvas.gameObject.GetComponent<Animator>().playbackTime = 0;
        Canvas.gameObject.GetComponent<Animator>().SetTrigger("GameOver");
        Canvas.gameObject.GetComponent<Animator>().speed = 0;
        SetBarrels();
        foreach (GameObject item in Level2Barrels)
        {
            item.SetActive(false);
        }
    }

    IEnumerator Invincibility() //Näkymättömyys, joka aktivoituu, kun pelaaja ottaa vahinkoa.
    {
        IsInvincible = true;
        gameObject.tag = "Untagged";
        gameObject.layer = 10;
        Debug.Log(gameObject.layer);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        foreach (GameObject item in ActiveBarrels)
        {
            item.SetActive(false);
        }
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        foreach (GameObject item in ActiveBarrels)
        {
            item.SetActive(true);
        }
        while (LoopedTime <= MaxInvincibilityLoopTime - 1)
        {
            yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            foreach (GameObject item in ActiveBarrels)
            {
                item.SetActive(false);
            }
            yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
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

    void Update()
    {
        if (combatMode == false)
        {
            if (Input.GetButton("Vertical"))
            {
                    rb2d.AddForce(transform.up * thrust);
                    //Fire.SetActive(true);
            } 

            if (Input.GetButton("Horizontal"))
            {
                rb2d.rotation = rb2d.rotation + rotationspeed * Input.GetAxis("Horizontal") * -1;
            }

            if (Input.GetButtonUp("Vertical"))
            {
                //Fire.SetActive(false);
            }
        }


        

        if (combatMode == true)
        {
            if (Input.GetButton("Vertical"))
            {
                rb2d.AddForce(new Vector2(0, 1) * thrust * Input.GetAxis("Vertical"));
            }

            if (Input.GetButton("Horizontal"))
            {
                rb2d.AddForce(new Vector2(1, 0) * thrust * Input.GetAxis("Horizontal"));
            }


        }
        if (Input.GetKeyDown("z"))
        {
            combatMode = !combatMode;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "PowerUp") //Powerupin saanti.
        {
            Debug.Log("Got a powerup!");
            if (level == 1) //Level 2.
            {
                level++;
                foreach (GameObject item in Level1Barrels)
                {
                    item.SetActive(false);

                }
                foreach (GameObject item in Level2Barrels)
                {
                    item.SetActive(true);
                }
                Destroy(collision.gameObject);
                return;

            }

            if (level == 2) // Level 3. Käytetään yhtä aikaa ensimmäisen ja toisen tason barreleita.
            {
                level++;
                foreach (GameObject item in Level1Barrels)
                {
                    item.SetActive(true);
                }
                Destroy(collision.gameObject);
            }
            return;
        }

        if (collision.tag == "Enemy")
        {
            if (IsInvincible == false)
            {
                Debug.Log("Met an enemy");

                if (level == 3) //Laskeminen levelistä 3 leveliin 2.
                {
                    level--;
                    foreach (GameObject item in Level1Barrels)
                    {
                        item.SetActive(false);
                    }
                    SetActiveBarrels();
                    StartCoroutine(Invincibility());
                    return;
                }

                if (level == 2) //Laskeminen levelistä 2 leveliin 1.
                {
                    level--;
                    foreach (GameObject item in Level2Barrels)
                    {
                        item.SetActive(false);
                    }
                    foreach (GameObject item in Level1Barrels)
                    {
                        item.SetActive(true);
                    }
                    SetActiveBarrels();
                    StartCoroutine(Invincibility());
                    return;
                }


                if (level == 1) //Game Over!
                {
                    ExplosionSprite.transform.position = gameObject.transform.position;
                    gameObject.SetActive(false);
                    ExplosionSprite.GetComponent<Animator>().Play("Explosion");
                    Canvas.gameObject.GetComponent<Animator>().speed = 1;


                }
                SetActiveBarrels();
                StartCoroutine(Invincibility());

            }
            Debug.Log(level);
        }
    }

    void SetActiveBarrels()
    {
        if (level == 3)
        {
            ActiveBarrels.Clear();
            foreach (GameObject item in Level1Barrels)
            {
                ActiveBarrels.Add(item);
            }

            foreach (GameObject item in Level2Barrels)
            {
                ActiveBarrels.Add(item);
            }
        }

        if (level == 2)
        {
            ActiveBarrels.Clear();

            foreach (GameObject item in Level2Barrels)
            {
                ActiveBarrels.Add(item);
            }
        }

        if (level == 1)
        {
            ActiveBarrels.Clear();

            foreach (GameObject item in Level1Barrels)
            {
                ActiveBarrels.Add(item);
            }
        }
        Debug.Log("Set active barrels");
    }
}
