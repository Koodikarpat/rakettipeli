using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject Rocket;
    public float CameraDistance;

    private void Start()
    {
        Rocket = GameObject.FindGameObjectWithTag("Player");
    }

    void Update () {
        Vector3 RocketLocation = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z - CameraDistance);
        gameObject.transform.localPosition = (RocketLocation);
	}
}
