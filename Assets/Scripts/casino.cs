using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casino : MonoBehaviour
{
    float numero = 3f;
    float voittoNumero = 2f;
    public GameObject palkinto;
    Animator animaatio;
    int kolikkoMaara;
    public int panos = 1;
    public float syöttöNopeus;
    GameObject pelaaja;
    Vector2 suunta;
    bool onkoPelattu;

    private void Start()
    {
        animaatio = GetComponent<Animator>();
        onkoPelattu = false;
    }

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        if (mihinTormattiin.CompareTag("Player") && !onkoPelattu)
        {
            kolikkoMaara = mihinTormattiin.GetComponent<kolikonKerays>().kolikkoLaskenta;
            numero = Random.Range(1, 5);
            Debug.Log("Saavuit casinoon");
                if (kolikkoMaara >= panos)
                {
                onkoPelattu = true;
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
    }
    public void AnnaPalkinto()
    {
        for (int i = 0; i < 20; i++)
        {
            pelaaja = GameObject.FindGameObjectWithTag("Player");
            suunta = (pelaaja.transform.position - transform.position);
            Rigidbody2D kolikkoInstance;
            kolikkoInstance = Instantiate(palkinto.GetComponent<Rigidbody2D>(), transform.position, transform.rotation) as Rigidbody2D;
            kolikkoInstance.AddForce(suunta * syöttöNopeus);
        }
    }
    
}
