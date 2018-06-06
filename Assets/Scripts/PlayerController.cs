using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    bool Move;
    private Rigidbody2D rb2d;
    public float thrust;
    public float rotationspeed;
    //public GameObject Fire;
    private float level;
    public GameObject[] Level1Barrels;
    public GameObject[] Level2Barrels;
    public GameObject ExplosionSprite;


   

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        //Fire.SetActive(false);
        level = 1;
        foreach (GameObject item in Level2Barrels)
        {
            item.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Vertical"))
        {
           
            {
                rb2d.AddForce(transform.up * thrust);
                //Fire.SetActive(true);
            }
        }

        if (Input.GetButton("Horizontal")){
            rb2d.rotation = rb2d.rotation + rotationspeed * Input.GetAxis("Horizontal") * -1;
        }

        if (Input.GetButtonUp("Vertical"))
        {
            //Fire.SetActive(false);
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
                Debug.Log(level);
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
            Debug.Log("Met an enemy");
            if (level == 3)
            {
                level--;
                foreach (GameObject item in Level1Barrels)
                {
                    item.SetActive(false);
                }
                return;
            }

            if (level == 2)
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
                return;
            }
        }
    }
}
