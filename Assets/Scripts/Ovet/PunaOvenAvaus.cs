using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunaOvenAvaus : MonoBehaviour {

    public bool onkoPelaajallaPunaAvain;

    void OnTriggerEnter2D(Collider2D mihinTormattiin)

    {
        if (mihinTormattiin.GetComponent<PelaajanAvaimet>().onkoPelaajallaPunaAvain)
        {
            Debug.Log("Ovi avautuu");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Ovi ei avaudu");
        }
    }
}
