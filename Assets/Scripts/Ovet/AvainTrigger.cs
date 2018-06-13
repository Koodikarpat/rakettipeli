using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvainTrigger : MonoBehaviour {

    //GetComponent<SpriteRendered2D>();

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        if (mihinTormattiin.gameObject.tag.Equals("Player"))
        {
            if (gameObject.name.Equals("avainkorttivihrea"))
            {
                mihinTormattiin.GetComponent<PelaajanAvaimet>().onkoPelaajallaVihreaAvain = true;
            }
            if (gameObject.name.Equals("avainkorttipunainen"))
            {
                mihinTormattiin.GetComponent<PelaajanAvaimet>().onkoPelaajallaPunaAvain = true;
            }
        }
            

            

    }
}
