using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmusInstantiate : MonoBehaviour {

    Vector2 ammuksenSuunta;

    public Rigidbody2D AmmusPrefab;
    public Transform barrelEnd;
    public GameObject Rocket;
    public float ammuksenNopeus;
    public float fireRate;

    private float Level;
    private float nextFire;





    void Update () {

        ammuksenSuunta = Rocket.transform.up;

        /*if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D AmmusInstance;
            AmmusInstance = Instantiate (AmmusPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;
            AmmusInstance.AddForce(ammuksenSuunta * ammuksenNopeus);
        }*/

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Rigidbody2D AmmusInstance;
            AmmusInstance = Instantiate(AmmusPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;
            AmmusInstance.AddForce(ammuksenSuunta * ammuksenNopeus);
        }
    }
}
