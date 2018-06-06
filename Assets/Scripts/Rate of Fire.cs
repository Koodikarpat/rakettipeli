using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateofFire : MonoBehaviour {

    public float fireRate;

    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
        }
    }
}
//Time.time