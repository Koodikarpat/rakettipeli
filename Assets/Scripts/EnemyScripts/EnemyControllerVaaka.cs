using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerVaaka : MonoBehaviour {

    private Vector2 startPos;

    public float Distance = 5.0f;
    public float Speed = 2.0f;
    private int Suunta;

    // Use this for initialization
    void Start () {
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 v = startPos;
        v.x += Distance * Mathf.Sin(Time.time * Speed);
        transform.position = v;
    }
}
