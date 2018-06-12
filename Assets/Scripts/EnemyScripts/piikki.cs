using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piikki : MonoBehaviour
{
    public float liikkumisnopeus = 50f;
    public bool pitaakoLiikkua;

    private void Update()
    {
        if (pitaakoLiikkua)
        {
            transform.position += transform.up * liikkumisnopeus * Time.deltaTime;
        }
    }
}
