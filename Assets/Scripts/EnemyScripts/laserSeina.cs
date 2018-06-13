using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserSeina : MonoBehaviour
{
    float aika; //Random.Range(0, 5);
    public float paallaoloAika = 5f;
    public float kiinnimenoAika = 10f;

    private void Start()
    {
        paallaoloAika = Random.Range(1, 3);
    }

    private void Update()
    {
        aika = aika + Time.deltaTime;
        if (aika > paallaoloAika)
        {
            GetComponent<Renderer>().enabled = false;
            kiinnimenoAika = Random.Range(1, 3) + paallaoloAika;
        }
        if (aika > kiinnimenoAika)
        {
            paallaoloAika = Random.Range(1, 3);
            GetComponent<Renderer>().enabled = true;
            aika = 0f;
        }
    }
}
