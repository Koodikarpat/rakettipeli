using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    private Vector2 PlayerPosition;
    public GameObject VihollisenAmmusPrefab;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {



    }
    private void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        if (mihinTormattiin.gameObject.tag == "Player") {
            Instantiate(VihollisenAmmusPrefab, transform.position, transform.rotation);
        }
    }
}
