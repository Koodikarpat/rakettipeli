using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmo : MonoBehaviour {

    public float BulletSpeed; //transform.up
    
	void Update () {

        transform.Translate(Vector2.down * BulletSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector2.right * BulletSpeed * Time.deltaTime, Space.World);
    }
}
