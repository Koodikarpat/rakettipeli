using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenAvaus : MonoBehaviour {

    public bool onkoPelaajallaAvain;
    Animator m_Animator;
    private GameObject avainkortti;
    public bool saapuuOvelle;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D mihinTormattiin)

    { 
    if (mihinTormattiin.gameObject.tag.Equals("Player") && mihinTormattiin.GetComponent<PelaajanAvaimet>().onkoPelaajallaAvain)
        {
            Debug.Log ("Ovi avautuu");
        
            m_Animator.SetTrigger("AvaaOvi2");

            saapuuOvelle = true;
        }
        else
        {
            Debug.Log ("Ovi ei avaudu");
        }
    }

}
