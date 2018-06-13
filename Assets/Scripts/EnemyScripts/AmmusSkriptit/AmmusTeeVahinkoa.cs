using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmusTeeVahinkoa : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Damage>().TakeDamage(1);
        }
    }
}

