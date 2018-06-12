using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserSeina : MonoBehaviour
{
    float aika;
    public float paallaoloAika = 5f;
    public float kiinnimenoAika = 10f;

    private void Update()
    {
        aika = aika + Time.deltaTime;
        if (aika > paallaoloAika)
        {
            GetComponent<Renderer>().enabled = false;
        }
        if (aika > kiinnimenoAika)
        {
            GetComponent<Renderer>().enabled = true;
            aika = 0f;
        }
    }
}
