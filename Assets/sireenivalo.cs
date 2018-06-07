using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sireenivalo : MonoBehaviour
{
    Vector3 minunVektori; //minunVektori = new Vector3(0, 0, 0);
    public float nopeus = 200f;

    private void Start()
    {
        Debug.Log("hmmm");
        minunVektori = new Vector3(0, 0, 1);
    }
    // Debug.Log("Jotaintekstiä");

    void Update ()
    {
        transform.Rotate(minunVektori * Time.deltaTime * nopeus);
	}
}
