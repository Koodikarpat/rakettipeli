using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piikitLiikkumaan : MonoBehaviour
{
    public GameObject[] piikit;
    Vector3 pyoriminen;
    public float pyorimisNopeus = 10f;

    private void Start()
    {
        pyoriminen = new Vector3(0, 0, 1);
    }

    private void Update()
    {
        transform.Rotate(pyoriminen * Time.deltaTime * pyorimisNopeus);
    }

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        for (int i = 0; i < piikit.Length; i++)
        {
            piikit[i].GetComponent<piikki>().pitaakoLiikkua = true;
            piikit[i].transform.parent = null;
        }
    }
}
