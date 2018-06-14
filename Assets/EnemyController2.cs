using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour {

    GameObject targetPosition;
    public Transform Player;
    public float Speed = 5;
    public float Distance = 20;
    private float Range;
    public Transform Enemy;
    Vector2 suunta;
    float kulma;

    private void Start()
    {
        targetPosition = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update () {

        if (targetPosition != null)
        {
            Player = targetPosition.transform;

            suunta = targetPosition.transform.position - transform.position;

            kulma = Mathf.Atan2(suunta.y, suunta.x) * Mathf.Rad2Deg - 90;


            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, kulma), Speed);
        }

        Range = Vector2.Distance(transform.position, Player.position);

        if (Range > Distance) {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D Tormays)
    {
        if (Tormays.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
