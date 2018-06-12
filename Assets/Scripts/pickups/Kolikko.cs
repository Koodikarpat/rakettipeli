using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolikko : MonoBehaviour {

    kolikonKerays kolikonKerays;

    private void Start()
    {
        kolikonKerays = GetComponent<kolikonKerays>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            kolikonKerays.kolikkoLaskenta++;
            Debug.Log("kolikkoja kerätty: " + kolikonKerays.kolikkoLaskenta);
        }
    }
}
