using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollisenAmmus : MonoBehaviour
{
    public float ammuksenNopeus = 10f; //Destroy(peliObjecti, aika);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "LevelRestriction")
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update ()
    {
        transform.position += transform.up * ammuksenNopeus * Time.deltaTime;
	}


}
