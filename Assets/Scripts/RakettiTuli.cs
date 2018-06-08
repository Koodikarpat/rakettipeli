using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakettiTuli : MonoBehaviour {

    float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        speed = GetComponent<Rigidbody2D>().velocity.magnitude;
        Debug.Log(speed);
    }
}
