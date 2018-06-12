using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kolikonKerays : MonoBehaviour
{
    public int kolikkoLaskenta;

        void Start()
    {
        kolikkoLaskenta = 0;
    }

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        if (mihinTormattiin.CompareTag("kolikko"))
        {
            mihinTormattiin.gameObject.SetActive(false);
            kolikkoLaskenta = kolikkoLaskenta + 1;
            Debug.Log("kolikkoja kerätty: " + kolikkoLaskenta);
        }
    }
}
