using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float scale = gameObject.transform.parent.GetComponentInChildren<Camera>().orthographicSize;
        //float scale = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        gameObject.transform.localScale = new Vector3(0.25f*scale, 0.17f*scale, 1);
	}
}
