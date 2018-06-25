using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripwire : MonoBehaviour {

    public GameObject spook;
    public GameObject player;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            spook.SetActive(true);
            Debug.Log("Yep");
        }
    }
}
