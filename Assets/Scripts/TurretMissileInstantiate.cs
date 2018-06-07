using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMissileInstantiate : MonoBehaviour {

    public Rigidbody2D missilePrefab;
    public Transform barrelEnd;
    private Vector2 suunta;
    private float aika = 0;
    public float fireRate = 1;
    private GameObject targetPosition;
    private Transform Position;
    Vector2 vektori;
    public float range;


    void Start()
    {

    }


    void Update()
    {
        targetPosition = GameObject.FindWithTag("Player");
        Position = targetPosition.transform;
        
        aika = aika + Time.deltaTime;

        vektori = Position.transform.position - transform.position;

        if (vektori.magnitude < range)
        {
            if (aika > fireRate)
            {
                suunta = barrelEnd.transform.position - transform.position;

                 Instantiate(missilePrefab, barrelEnd.position, barrelEnd.rotation);                
                aika = 0;
            }
        }


    }
}
