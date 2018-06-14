using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAvainTrigger : MonoBehaviour {

    public GameObject ansat;
    public Color altColor;
    public Renderer rend;

    void Start ()
    {
        rend = GetComponent<Renderer>();
    }

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
         if(mihinTormattiin.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Nappia painettu");
            ansat.SetActive(false);
            altColor.g = 10f;
            rend.material.color = altColor;
        }
    }
}
