using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    bool combatMode = false;
    private Rigidbody2D rb2d;
    public float thrust;
    public float rotationspeed;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update () {
        if (combatMode == false)
        {
            if (Input.GetButton("Vertical"))
            {
                rb2d.AddForce(transform.up * thrust);
                //Fire.SetActive(true);
            }

            if (Input.GetButton("Horizontal"))
            {
                rb2d.rotation = rb2d.rotation + rotationspeed * Input.GetAxis("Horizontal") * -1;
            }

            if (Input.GetButtonUp("Vertical"))
            {
                //Fire.SetActive(false);
            }
        }




        if (combatMode == true)
        {
            if (Input.GetButton("Vertical"))
            {
                rb2d.AddForce(new Vector2(0, 1) * thrust * Input.GetAxis("Vertical"));
            }

            if (Input.GetButton("Horizontal"))
            {
                rb2d.AddForce(new Vector2(1, 0) * thrust * Input.GetAxis("Horizontal"));
            }


        }
        if (Input.GetKeyDown("z"))
        {
            combatMode = !combatMode;
            if (combatMode == true)
            {
                gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            }

            if (combatMode == false)
            {
                gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            }
        }
    }
}
