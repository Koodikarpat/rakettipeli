using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour {

    private GameObject targetPosition;
    private Transform Position;
    public float Matka = 10.0f;
    Vector2 suunta;
    float kulma;
    public float nopeus = 1;

    private void Start()
    {
        targetPosition = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (targetPosition != null)
        {
            Position = targetPosition.transform;

            suunta = targetPosition.transform.position - transform.position;

            kulma = Mathf.Atan2(suunta.y, suunta.x) * Mathf.Rad2Deg - 90;


            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, kulma), nopeus);
        }
       

        
        
    }

}