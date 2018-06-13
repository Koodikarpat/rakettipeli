using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sirkkeliAnsa : MonoBehaviour
{
    Vector3 pyorin;
    public float pyorimisNopeus = 10f;

    private void Start()
    {
        pyorin = new Vector3(0, 0, 1);
    }
    private void Update()
    {
        transform.Rotate(pyorin * Time.deltaTime * pyorimisNopeus);
    }
}
