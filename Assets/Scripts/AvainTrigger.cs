using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvainTrigger : MonoBehaviour {

    //GetComponent<SpriteRendered2D>();

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        Debug.Log("Avain saatu");
        bool onkoPelaajallaAvain = true;
        mihinTormattiin.GetComponent<PelaajanAvaimet>().onkoPelaajallaAvain = true;
    }
}
