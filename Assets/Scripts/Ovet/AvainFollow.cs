using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvainFollow : MonoBehaviour {

    private Rigidbody2D rb2D;
    public float thrust;
    public bool avainTormays;
    private GameObject player;
    private GameObject door;
    //
    

    // Use this for initialization
    void Start () {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D mihinTormattiin) {
        if (mihinTormattiin.gameObject.tag.Equals("Player"))
        {
            avainTormays = true;
        }
        if (mihinTormattiin.gameObject.tag.Equals("Door"))
        {
            if (mihinTormattiin.GetComponent<OvenAvaus>().saapuuVihreaOvelle && gameObject.name.Equals("avainkorttivihrea"))
            {
                Destroy(gameObject);
            }
            if (mihinTormattiin.GetComponent<OvenAvaus>().saapuuPunaOvelle && gameObject.name.Equals("avainkorttipunainen"))
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if (avainTormays)
        {
            rb2D.AddForce((player.transform.position - transform.position) * thrust);
        }
    }
}






