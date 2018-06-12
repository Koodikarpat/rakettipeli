﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmusDestruction : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollsionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "LevelRestriction")
        {
            Debug.Log("Hit the player.");
            Destroy(gameObject);
        }
    }
}
