using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{

    public int level;
    public GameObject[] Level1Barrels; //Barrelit, joita käytetään levelissä 1.
    public GameObject[] Level2Barrels; //Barrelit, joita käytetään levelissä 2.

    private void Start()
    {
        level = 1;
        foreach (GameObject item in Level2Barrels)
        {
            item.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PowerUp") //Powerupin saadessaan pelaajan leveli nousee, jolloin pelaaja saa lisää tykkejä käyttöönsä. 1 level = 1 tykki lisää.
        {
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
        }
    }
}
