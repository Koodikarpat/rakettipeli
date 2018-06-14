using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmusDestruction : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "LevelRestriction")
        {
            Debug.Log("Hit the player.");
            Destroy(gameObject);
        }
    }
}
