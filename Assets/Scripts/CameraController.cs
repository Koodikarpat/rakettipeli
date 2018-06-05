using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Rocket;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 RocketLocation = new Vector3(Rocket.transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z - 10);
        gameObject.transform.localPosition = (RocketLocation);
	}
}
