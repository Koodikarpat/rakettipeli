using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaustanLiike : MonoBehaviour {

    
    public float liikeMäärä;

    private Vector3 camStart;
    private Transform camMove;
    

	// Use this for initialization
	void Start () {

        camMove = Camera.main.transform;
        
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        camStart = new Vector3 (camMove.position.x, camMove.position.y, 0);
        transform.position = new Vector3(camMove.position.x, camMove.position.y, 9) - camStart * liikeMäärä ;
	}
}
