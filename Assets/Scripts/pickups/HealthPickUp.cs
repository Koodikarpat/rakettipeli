﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //Pelaajalla on vielä kolmas collider lapsena, jotta pickupit toimisivat. Jos käyttäisi pelaajan collidereita, pelaaja saisi aina 2 leveliä yhdestä pickupista.
        {
            collision.gameObject.GetComponent<PlayerHealth>().playerHealth++;
            Destroy(gameObject);
        }
    }
}
