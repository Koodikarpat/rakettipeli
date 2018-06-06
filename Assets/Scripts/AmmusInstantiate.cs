using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmusInstantiate : MonoBehaviour {

    public Rigidbody2D AmmusPrefab;
    public Transform barrelEnd;
    Vector2 ammuksenSuunta;
    public float ammuksenNopeus;
    private float Level;
    public GameObject Rocket;


	void Update () {
        ammuksenSuunta = Rocket.transform.up;
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D AmmusInstance;
            AmmusInstance = Instantiate (AmmusPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;
            AmmusInstance.AddForce(ammuksenSuunta * ammuksenNopeus);
        }
	}
}
