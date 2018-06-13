using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : MonoBehaviour {
    public GameObject BossRestriction;
    private GameObject Player;
    private GameObject Camera;
    public Transform BossLocation;
    public GameObject Boss;
    public bool BossHasStarted;
    public float CameraSizeInBossBattle;
    public AudioClip BossMusic;

    private void Start()
    {
        BossRestriction.SetActive(false);
    }

    IEnumerator ActivateBoss()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerMovement>().enabled = false;
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Camera.GetComponent<CameraController>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        Camera.transform.position = new Vector3(BossRestriction.transform.position.x, BossRestriction.transform.position.y, -1);
        yield return new WaitForSeconds(1);
        BossRestriction.SetActive(true);
        yield return new WaitForSeconds(1);
        Camera.GetComponent<Camera>().orthographicSize = 20;
        Camera.transform.position = new Vector3(BossLocation.transform.position.x, BossLocation.transform.position.y, -1);
        yield return new WaitForSeconds(1);
        Instantiate(Boss, BossLocation.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Camera.GetComponent<CameraController>().enabled = true;
        Camera.GetComponent<Camera>().orthographicSize = CameraSizeInBossBattle;
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<AudioSource>().clip = BossMusic;
        Player.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        BossHasStarted = true;
        

        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(ActivateBoss());
        }
    }
}
