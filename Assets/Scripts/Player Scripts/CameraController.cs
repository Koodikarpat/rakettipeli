using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject Rocket;
    public float CameraDistance;
    public float CameraSizeAtStart;
    public float cameraPosition;
    public float smoothing;

    private void Start()
    {
        Rocket = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Camera>().orthographicSize = CameraSizeAtStart;
        Vector3 RocketLocation = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z - CameraDistance);
        gameObject.transform.position = (RocketLocation);
    }

    void Update () {
        Vector3 RocketLocation = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z - CameraDistance);
        gameObject.transform.position =  Vector3.Lerp(transform.position, new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, -CameraDistance) + cameraPosition * Rocket.transform.up, smoothing);
	}
}
