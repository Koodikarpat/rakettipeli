using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour {

    private GameObject targetPosition;
    private Transform Position;
    Vector2 suunta;
    float kulma;

    private void Start()
    {
        
    }
    void Update()
    {
        targetPosition = GameObject.FindWithTag("Player");
        Position = targetPosition.transform;

        suunta = targetPosition.transform.position - transform.position;

        kulma = Mathf.Atan2(suunta.y, suunta.x) * Mathf.Rad2Deg - 90;

        
        transform.rotation = Quaternion.Euler(0, 0, kulma );

    }

}