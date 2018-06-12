using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject Rocket;
    public float CameraDistance;
    public float CameraSizeAtStart;

    private void Start()
    {
        Rocket = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Camera>().orthographicSize = CameraSizeAtStart;
    }

    void Update () {
        Vector3 RocketLocation = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z - CameraDistance);
        gameObject.transform.localPosition = (RocketLocation);
	}
}
