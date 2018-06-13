using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casino : MonoBehaviour
{
    float numero = 3f;
    float voittoNumero = 2f;
    public GameObject palkinto;
    public GameObject esineenPaikka;
    Animator animaatio;
    int kolikkoMaara;
    public int panos = 1;

    private void Start()
    {
        animaatio = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        kolikkoMaara = mihinTormattiin.GetComponent<kolikonKerays>().kolikkoLaskenta;
        numero = Random.Range(1, 5);
        Debug.Log("Saavuit casinoon");
        if (kolikkoMaara >= panos)
        {
            if (numero == voittoNumero)
            {
                animaatio.SetTrigger("Voitto");
                Debug.Log("Voitto!");
            }
            else
            {
                animaatio.SetTrigger("Häviö");
                Debug.Log("ei voittoa");
            }
        }
        else
        {
            Debug.Log("ei peliä");
        }
    }
    public void AnnaPalkinto()
    {
        Instantiate(palkinto, esineenPaikka.transform.transform.position, esineenPaikka.transform.rotation);
    }
    
}
