using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakettiTuli : MonoBehaviour {

    float speed;
    public float pittusKerroin = 0.05f;
    public GameObject tuli;
    float pituus;
    PlayerMovement pmScript; //PlayerMovement scripti
    float satunnaisuus;
    
	// Use this for initialization
	void Start () {
        pmScript = GetComponent<PlayerMovement>();
        Debug.Log("Huhuu");
    }
	
	// Update is called once per frame
	void Update () {
        satunnaisuus = Random.Range(0.9f, 1);
        if (pmScript.combatMode == false)
        {
            speed = GetComponent<Rigidbody2D>().velocity.magnitude;

            pituus = speed * pittusKerroin;
            tuli.transform.localScale = new Vector3(pituus*satunnaisuus, pituus*satunnaisuus, 1);
        }
        else
        {
            tuli.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
