using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDirection : MonoBehaviour {
    public float asteroidSpeed;
    Rigidbody2D asteroid;
    Vector2 asteroidDirection;

    void Start () {
        int x = Random.Range(-2, 2);
        int y = Random.Range(-2, 2);
        asteroidDirection = new Vector2(x, y);
        asteroid = GetComponent<Rigidbody2D>();
        asteroid.AddForce(asteroidDirection * asteroidSpeed);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,20)*Time.deltaTime);
    }
}