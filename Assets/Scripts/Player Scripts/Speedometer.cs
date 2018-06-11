﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour {

    float speed;
    public GameObject raketti;
    float kulma;
    public float nopeusKerroin = 8;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        speed = raketti.GetComponent<Rigidbody2D>().velocity.magnitude;

        kulma = speed * nopeusKerroin;

        transform.rotation = Quaternion.Euler(0, 0, -kulma);

    }
}
