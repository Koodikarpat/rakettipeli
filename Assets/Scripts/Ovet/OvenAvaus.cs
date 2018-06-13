using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenAvaus : MonoBehaviour {

    public bool onkoPelaajallaAvain;
    Animator m_Animator;
    private GameObject avainkortti;
    public bool saapuuVihreaOvelle;
    public bool saapuuPunaOvelle;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D mihinTormattiin)

    {
        if (mihinTormattiin.gameObject.tag.Equals("Player")) 
        {
            if (gameObject.name.Equals("kaksoisovetvihrea"))
            {
                if (mihinTormattiin.GetComponent<PelaajanAvaimet>().onkoPelaajallaVihreaAvain)
                {

                    m_Animator.SetTrigger("AvaaOvi");
                    saapuuVihreaOvelle = true;
                }
            }
            if (gameObject.name.Equals("kaksoisovetpuna"))
            {
                if (mihinTormattiin.GetComponent<PelaajanAvaimet>().onkoPelaajallaPunaAvain)
                {

                    m_Animator.SetTrigger("AvaaOvi");
                    saapuuPunaOvelle = true;
                }
            }

        }
            
    }
}



