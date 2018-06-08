using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerController Rocket;
    public float CameraDistance;


	void Update () {
        Vector3 RocketLocation = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z - CameraDistance);
        gameObject.transform.localPosition = (RocketLocation);
	}
}
