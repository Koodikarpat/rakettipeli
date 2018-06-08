using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenAvaus : MonoBehaviour {

    public bool onkoPelaajallaAvain;

    void OnTriggerEnter2D(Collider2D mihinTormattiin)

    { 
    if (mihinTormattiin.GetComponent<PelaajanAvaimet>().onkoPelaajallaAvain)
        {
            Debug.Log ("Ovi avautuu");
            Destroy(gameObject);
        }
    else
        {
            Debug.Log ("Ovi ei avaudu");
        }
    }

}
