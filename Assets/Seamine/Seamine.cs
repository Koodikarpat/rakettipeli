using System.Collections;
using UnityEngine;

public class Seamine : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject player;
    public float speed;
    public float followingdistance;
    public float explosiondistance;
    SpriteRenderer sr;
    public Sprite undisturbed;
    public Sprite following;
    public Sprite explode;
    public GameObject ExplosionParticle;
    bool exploding;
    float etaisyysPelaajaan;

    private Vector2 offset;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    IEnumerator Example()
    {
        sr.sprite = explode;
        yield return new WaitForSeconds(3);
        if (etaisyysPelaajaan < explosiondistance)
        {
            player.GetComponent<Damage>().TakeDamage(1);

        }
        Destroy(gameObject);
        Instantiate(ExplosionParticle, gameObject.transform.position, Quaternion.identity);
        
    }

    void FixedUpdate()
    {
        Vector2 suuntaMiinastaPelaajaan = player.transform.position - transform.position;
        etaisyysPelaajaan = suuntaMiinastaPelaajaan.magnitude;
        if (etaisyysPelaajaan < followingdistance && !exploding)
        {
            sr.sprite = following;
            rb.AddForce(suuntaMiinastaPelaajaan * speed);
        }
        
        if (etaisyysPelaajaan < explosiondistance)
        {
            exploding = true;
            sr.sprite = explode;
            StartCoroutine(Example());
        }
        else if (etaisyysPelaajaan > followingdistance)
        {
            sr.sprite = undisturbed;
        }
        if (exploding == true)
        {
            sr.sprite = explode;
        }
    }
}
