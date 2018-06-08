using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakettiTuli : MonoBehaviour {

    float speed;
    public float pittusKerroin = 0.05f;
    public GameObject tuli;
    float pituus;
    PlayerMovement pmScript; //PlayerMovement scripti
    
	// Use this for initialization
	void Start () {
        pmScript = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (pmScript.combatMode == false)
        {
            speed = GetComponent<Rigidbody2D>().velocity.magnitude;
            

            pituus = speed * pittusKerroin;

            tuli.transform.localScale = new Vector3(pituus, pituus, 1);
        }
        else
        {
            tuli.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
