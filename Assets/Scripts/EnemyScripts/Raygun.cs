using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raygun : MonoBehaviour
{
    bool active = true;
    float aika = 0;
    public float reloadTime = 2;
    public GameObject ammus;
    public GameObject barrelEnd;
    Vector2 suunta;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
           active = false;

        }
        

    }
    private void Update()
    {
        if (active == false )
        {
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up) ;
            Debug.Log(hit);
            if (aika == 0)
            {
                Instantiate(ammus, barrelEnd.transform.position, barrelEnd.transform.rotation);
            }
            GetComponent<BoxCollider2D>().enabled = false;
            aika = aika + Time.deltaTime;
            
            if (aika >= reloadTime)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                aika = 0;
            }
        }
    }
}
