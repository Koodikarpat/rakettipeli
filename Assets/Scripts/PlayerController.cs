using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    bool Move;
    private Rigidbody2D rb2d;
    public float thrust;
    public float rotationspeed;
    //public GameObject Fire;
    public float level;
    public GameObject[] Level1Barrels;
    public GameObject[] Level2Barrels;
    public GameObject ExplosionSprite;
    public float InvincibilityTime;
    public float InvincibilitySpeed;
    private bool IsInvincible;
    bool combatMode = false;
    
    



    
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        //Fire.SetActive(false);
        level = 2;
        foreach (GameObject item in Level2Barrels)
        {
            item.SetActive(false);
        }
	}

    IEnumerator Invincibility()
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
	
	
	void Update ()
    {
        if (combatMode == false)
        {
            if (Input.GetButton("Vertical"))
            {

                {
                    rb2d.AddForce(transform.up * thrust);
                    //Fire.SetActive(true);
                }
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

                {
                    rb2d.AddForce(transform.up * thrust);
                    
                }
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            combatMode = !combatMode;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "PowerUp")
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
                StartCoroutine(Invincibility());
                Debug.Log("Met an enemy");
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
                    return;
                }


                if (level == 1)
                {
                    ExplosionSprite.transform.position = gameObject.transform.position;
                    Destroy(gameObject);
                    ExplosionSprite.GetComponent<Animator>().Play("Explosion");

                }
            }
        }
    }
}
