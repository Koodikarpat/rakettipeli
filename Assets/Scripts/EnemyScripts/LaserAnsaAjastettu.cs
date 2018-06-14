using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnsaAjastettu : MonoBehaviour {

    float aika = 0;
    public float charge = 2;
    public GameObject ammus;
    public GameObject tähtäin;
    public float kesto;
    public float aloitusAika;
    public float cooldown;
    

	// Use this for initialization
	void Start () {
        aika = -aloitusAika;
        tähtäin.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit2D[] hits;
        Debug.DrawRay(transform.position, transform.up);
        hits = Physics2D.RaycastAll(transform.position, transform.up, 10000); // Tunnistaa kaikki objektit  10000 yksikön päähän tykin edessä

        float pituus = 10000;

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.distance < pituus)
            {
                if (hit.transform.tag == "LevelRestriction")
                {
                    pituus = hit.distance;
                }
            }
        }


        tähtäin.transform.localScale = new Vector3(1, pituus, 1);
        ammus.transform.localScale = new Vector3(1, pituus, 1);//muuttaa tähtäimen ja ammuksen pituuden oikeaksi.

        aika = aika + Time.deltaTime;



        if (aika > 0)
        {
            tähtäin.SetActive(true);
        }





        if (aika >= charge)
        {
            ammus.SetActive(true);
            tähtäin.SetActive(false);




        }
        if (aika >= charge + kesto)
        {
            ammus.SetActive(false);
            aika = - cooldown;

            

        }

    }
}
