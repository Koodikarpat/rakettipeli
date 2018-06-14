using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OviNappiTrigger : MonoBehaviour {

    public GameObject nappiOvi;
    public Color altColor;
    public Renderer rend;
    

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        if(mihinTormattiin.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Nappia painettu");
            nappiOvi.GetComponent<Animator>().SetTrigger("AvaaOvi");
            altColor.g = 10f;
            rend.material.color = altColor;
        }
    }
}
