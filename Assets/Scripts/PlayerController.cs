using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

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


   
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Canvas.gameObject.SetActive(false);
        //Fire.SetActive(false);
        level = 1;
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
        gameObject.GetComponent<SpriteRenderer>().enabled=false;
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(InvincibilityTime / InvincibilitySpeed);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        IsInvincible = false;
        gameObject.tag = "Player";
        gameObject.layer = 9;
    }
	
	void Update () {
        if (Input.GetButton("Vertical")) //Jos painaa ylös, menee ylös. Magic!
        {
           
            {
                rb2d.AddForce(transform.up * thrust);
                //Fire.SetActive(true);
            }
        }

        if (Input.GetButton("Horizontal")){ //Hallitsee kääntämistä. RotationSpeed hallitsee kääntymisnopeutta.
            rb2d.rotation = rb2d.rotation + rotationspeed * Input.GetAxis("Horizontal") * -1;
        }

        if (Input.GetButtonUp("Vertical")) //Vanha toiminto, jossa raketille ilmestyi tulta kun liikkui.
        {
            //Fire.SetActive(false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
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
                foreach(GameObject item in Level2Barrels)
                {
                    item.SetActive(true);
                }
                Destroy(collision.gameObject);
                return;

            }

            if (level == 2) // Level 3. Käytetään yhtä aikaa ensimmäisen ja toisen tason barreleita.
            {
                level++;
                foreach (GameObject item in Level1Barrels){
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
                StartCoroutine(Invincibility());
                if (level == 3) //Laskeminen levelistä 3 leveliin 2.
                {
                    level--;
                    foreach (GameObject item in Level1Barrels)
                    {
                        item.SetActive(false);
                    }
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
                    return;
                }


                if (level == 1) //Game Over!
                {
                    ExplosionSprite.transform.position = gameObject.transform.position;
                    Destroy(gameObject);
                    ExplosionSprite.GetComponent<Animator>().Play("Explosion");
                    Canvas.gameObject.SetActive(true);
                    Canvas.gameObject.GetComponent<Animator>().SetTrigger("GameOver");
                    
                }
            
            }
         Debug.Log(level);
        }
    }
}
