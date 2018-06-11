using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int playerHealth;

    private void Start()
    {
        playerHealth = 3;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HealthPickUp")
        {
                playerHealth++;
                Destroy(collision.gameObject);
        }
    }
}
