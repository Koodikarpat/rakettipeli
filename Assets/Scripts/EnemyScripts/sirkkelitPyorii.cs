using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sirkkelitPyorii : MonoBehaviour
{
    Vector3 vektori;
    float pyorintaNopeus = 100f;

    private void Start()
    {
        vektori = new Vector3(0, 0, 1);
    }
    private void Update()
    {
        transform.Rotate(vektori * Time.deltaTime * pyorintaNopeus);
    }
}
