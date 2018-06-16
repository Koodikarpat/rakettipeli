using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour {

	//Tämä scripti muuttaa taustan kokoa kameran koon mukaan. Tätä ei kannata käyttää animaatioissa tai siirtymissä.


	void Update () {
        float scale = gameObject.transform.parent.GetComponentInChildren<Camera>().orthographicSize;
        //float scale = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        gameObject.transform.localScale = new Vector3(0.25f*scale, 0.17f*scale, 1);
	}
}
