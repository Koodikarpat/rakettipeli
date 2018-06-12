using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kauppa : MonoBehaviour
{
    int kolikkojenmaara;
    public int varasto = 3;
    public int hinta = 1;
    public GameObject tuote;

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        kolikkojenmaara = mihinTormattiin.GetComponent<kolikonKerays>().kolikkoLaskenta;
        Debug.Log("saavuit kauppaan");
        if (varasto > 0)
        {
            if (kolikkojenmaara >= hinta)
            {
                Debug.Log("kolikkojen määrä: " + kolikkojenmaara);
                Debug.Log("kaupat tuli!");
                varasto = varasto - 1;
                Instantiate(tuote, transform.position, transform.rotation);
                mihinTormattiin.GetComponent<kolikonKerays>().kolikkoLaskenta -= hinta;
            }
            else
            {
                Debug.Log("kolikkojen määrä: " + kolikkojenmaara);
                Debug.Log("Ei kauppoja");
            }
        }
        else
        {
            Debug.Log("ei myydä mitään");
        }
    }
}
