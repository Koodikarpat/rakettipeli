using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaygunRotator : MonoBehaviour
{

    private GameObject targetPosition;
    private Transform Position;
    Vector2 suunta;
    float kulma;
    public float nopeus = 1;
    float aika = 0f;
    Raygun rayScript; // raygun skripti

    private void Start()
    {
        rayScript = GetComponent<Raygun>();
        targetPosition = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
        if (rayScript.active)
        {

                Position = targetPosition.transform;

                suunta = targetPosition.transform.position - transform.position;

                kulma = Mathf.Atan2(suunta.y, suunta.x) * Mathf.Rad2Deg - 90;


                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, kulma), nopeus);
            
        }

    }

}