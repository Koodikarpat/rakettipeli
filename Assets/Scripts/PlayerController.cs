using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    bool Move;
    private Rigidbody2D rb2d;
    public float thrust;
    public float rotationspeed;
    public GameObject Fire;

   

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Fire.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Vertical"))
        {
           
            {
                rb2d.AddForce(transform.up * thrust);
                Fire.SetActive(true);
            }
        }

        if (Input.GetButton("Horizontal")){
            rb2d.rotation = rb2d.rotation + rotationspeed * Input.GetAxis("Horizontal") * -1;
        }

        if (Input.GetButtonUp("Vertical"))
        {
            Fire.SetActive(false);
        }
	}

    private void FixedUpdate()
    {
        
    }
}
