using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{

    public Rigidbody2D ammusPrefab;
    public Transform barrelEnd;
    private Vector2 suunta;
    public int lahtonopeus;
    private float aika = 0;
    public float fireRate = 1;
    private GameObject targetPosition;
    private Transform Position;
    Vector2 vektori;
    public float range;


    void Start()
    {
        targetPosition = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Position = targetPosition.transform; 
        aika = aika + Time.deltaTime;

        vektori = Position.transform.position - transform.position;

        if (vektori.magnitude < range)
        {
            if (aika > fireRate)
            {
                suunta = barrelEnd.transform.position - transform.position;


                Rigidbody2D ampuminen;
                ampuminen = Instantiate(ammusPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody2D;
                ampuminen.AddForce(suunta * lahtonopeus);
                aika = 0;
            }
        }


    }
}
