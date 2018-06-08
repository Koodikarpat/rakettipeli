using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunaAvainTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        Debug.Log("Avain saatu");
        bool onkoPelaajallaPunaAvain = true;
        mihinTormattiin.GetComponent<PelaajanAvaimet>().onkoPelaajallaPunaAvain = true;
    }
}

