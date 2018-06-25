using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripwireBoss : MonoBehaviour
{
    
    public GameObject player;
    public GameObject wire;
    public GameObject wire2;
    public GameObject button;
    public GameObject button2;
    public GameObject walls;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            wire.SetActive(false);
            wire2.SetActive(false);
            button.SetActive(false);
            button2.SetActive(false);
            walls.SetActive(true);

        }
    }
}
