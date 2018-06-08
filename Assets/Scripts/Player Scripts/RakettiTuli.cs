using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakettiTuli : MonoBehaviour {

    float speed;
    float pituus;
    public float pittusKerroin = 0.05f;
    public GameObject tuli;
    bool combatMode = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (combatMode == false)
        {
            speed = GetComponent<Rigidbody2D>().velocity.magnitude;
            

            pituus = speed * pittusKerroin;

            tuli.transform.localScale = new Vector3(pituus, pituus, 1);
        }
        if (Input.GetKey(KeyCode.Z)) 
        {
            combatMode = !combatMode;
        }
    }
}
