using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmusDestruction : MonoBehaviour {

    public float destructionTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("ayy");
        if (collision.tag == "LevelRestriction")
        {
            //Debug.Log("Hit level restriction!");
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start() {
        Destroy(gameObject, 2f);
    }

    
}