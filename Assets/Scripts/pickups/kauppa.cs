using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kauppa : MonoBehaviour
{
    int kolikkojenmaara;
    public int varasto = 3;
    public int hinta = 1;
    public GameObject tuote;
    GameObject pelaaja;
    public float voimanLisäys;
    Vector2 suunta;

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        if (mihinTormattiin.CompareTag("Player"))
        {
            kolikkojenmaara = mihinTormattiin.GetComponent<kolikonKerays>().kolikkoLaskenta;
            Debug.Log("saavuit kauppaan");
            if (varasto > 0)
            {
                if (kolikkojenmaara >= hinta)
                {
                    Debug.Log("kaupat tuli!");
                    varasto = varasto - 1;

                    pelaaja = GameObject.FindGameObjectWithTag("Player");
                    suunta = (pelaaja.transform.position - transform.position);
                    Rigidbody2D kolikkoInstance;
                    kolikkoInstance = Instantiate(tuote.GetComponent<Rigidbody2D>(), transform.position, transform.rotation)as Rigidbody2D;
                    kolikkoInstance.AddForce(suunta * voimanLisäys);

                    mihinTormattiin.GetComponent<kolikonKerays>().kolikkoLaskenta -= hinta;
                }
                else
                {
                    Debug.Log("Ei kauppoja");
                }
            }
            else
            {
                Debug.Log("ei myydä mitään");
            }
        }
    }
}
