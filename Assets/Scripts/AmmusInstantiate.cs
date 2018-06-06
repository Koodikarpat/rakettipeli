using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmusInstantiate : MonoBehaviour {

    public Rigidbody AmmusPrefab;
    public Transform barrelEnd;
    Vector2 ammuksenSuunta;
    public float ammuksenNopeus;

	void Update () {
        ammuksenSuunta = barrelEnd.position - transform.position;
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody AmmusInstance;
            AmmusInstance = Instantiate (AmmusPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            AmmusInstance.AddForce(ammuksenSuunta * ammuksenNopeus);
        }
	}
}
