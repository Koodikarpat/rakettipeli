﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmusDestruction : MonoBehaviour {

    public float Lifetime;

    void Start()
    {
        Destroy(gameObject, Lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "LevelRestriction")
        {
            Destroy(gameObject);
        }
    }
}
