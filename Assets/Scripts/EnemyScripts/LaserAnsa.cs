using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAnsa : MonoBehaviour
{
    public Rigidbody TykinAmmusPrefab;
    public Transform barrelEnd;


    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log ("Object entered the trigger");
       
        Rigidbody TykinAmmusInstance;
        TykinAmmusInstance = Instantiate(TykinAmmusPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
        TykinAmmusInstance.AddForce(barrelEnd.forward * 1000);
          
        }

	
	}

