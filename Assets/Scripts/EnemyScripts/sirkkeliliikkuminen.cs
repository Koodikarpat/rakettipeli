using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sirkkeliliikkuminen : MonoBehaviour
{
    public float nopeus = 100f;
    Vector3 munvektori;
    public Vector3 ykkösvektori;
    Vector3 sirkkelinkoti;
    public float nopee = 50f; //transform.position = transform.position + Vector3.right);
    float Aika;
    public float matka = 1f;

    private void Start()
    {
        munvektori = new Vector3(0, 0, 1);
        sirkkelinkoti = transform.position;
    }

    void Update ()
    {
       /* {
            transform.Rotate(munvektori * Time.deltaTime * nopeus);
        }*/
        Aika = Aika + Time.deltaTime;
        if (Aika < matka)
        {
            transform.position += ykkösvektori * nopee;
        }
        else
            {
            transform.position += -ykkösvektori * nopee;
            }
        if (Aika > matka * 2)
        {
            Aika = 0; //transform.position = ykkösvektori;
            transform.position = sirkkelinkoti;
        }
    }
}
