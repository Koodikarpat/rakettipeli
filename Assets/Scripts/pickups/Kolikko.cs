using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolikko : MonoBehaviour {

    kolikonKerays kolikonKerays;
    public GameObject pelaaja;

    private void Start()
    {
        kolikonKerays = pelaaja.GetComponent<kolikonKerays>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            kolikonKerays.kolikkoLaskenta++;
            gameObject.SetActive(false);
            Debug.Log("kolikkoja kerätty: " + kolikonKerays.kolikkoLaskenta);
        }
    }
}
