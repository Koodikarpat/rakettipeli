﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raygun : MonoBehaviour
{
    public bool active = true;
    float aika = 0f;
    float aika1 = 0f;
    public float charge = 2;
    public GameObject ammus;
    public GameObject barrelEnd;
    public GameObject tähtäin;
    public float Tähtäysaika;
    
    

    private void Start()
    {
        tähtäin.SetActive(false);
        ammus.SetActive(false);
        active = true;
    }

    private void OnTriggerStay2D(Collider2D collision) //tunnistaa, jos pelaaja on tykin rangella.
    {
        if (collision.tag == "Player")
        {
                           
                active = false;
                aika = 0;
            
        }
        

    }
    private void Update()
    {

        RaycastHit2D[] hits;
        Debug.DrawRay(barrelEnd.transform.position, transform.up);
        hits = Physics2D.RaycastAll(barrelEnd.transform.position, transform.up, 10000); // Tunnistaa kaikki objektit  10000 yksikön päähän tykin edessä

        float pituus = 10000;
        
        foreach(RaycastHit2D hit in hits)
        {
            if(hit.distance < pituus)
            {
                if (hit.transform.tag == "LevelRestriction")
                {
                    pituus = hit.distance;
                }
            }
        }

      
                tähtäin.transform.localScale = new Vector3(1, pituus, 1);
                ammus.transform.localScale = new Vector3(1, pituus, 1);//muuttaa tähtäimen ja ammuksen pituuden oikeaksi.


        if (active == false )
        {
            GetComponent<BoxCollider2D>().enabled = false;
            aika = aika + Time.deltaTime;
            
            
            
            if (aika > Tähtäysaika)
            {
                tähtäin.SetActive(true);
            }
            
            



            if (aika >= charge)
            {
                ammus.SetActive(true);
                tähtäin.SetActive(false);

               
                
                
            }
            if (aika >= charge + 0.5f)
            {
                ammus.SetActive(false);
                aika = 0;
                GetComponent<BoxCollider2D>().enabled = true;
                active = true;

            }

            
        }
    }
}
