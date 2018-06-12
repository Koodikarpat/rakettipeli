using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollisenAmmus : MonoBehaviour
{
    public float ammuksenNopeus = 10f; //Destroy(peliObjecti, aika);

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update ()
    {
        transform.position += transform.up * ammuksenNopeus * Time.deltaTime;
	}
}
