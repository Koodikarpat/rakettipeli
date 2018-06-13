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
    private GameObject InstantiatedBoss;
    public Animator BossAppearance;
    public float BossRestrictionHeight;
    public string AnimationTrigger;

    private void Start()
    {
        BossRestriction.transform.localScale = new Vector3(1f, 0f, 1f);
    }

    

    IEnumerator ActivateBoss()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponentInChildren<AmmusInstantiate>().enabled = false;
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Camera.GetComponent<CameraController>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        Camera.transform.position = new Vector3(BossRestriction.transform.position.x, BossRestriction.transform.position.y, -1);
        yield return new WaitForSeconds(1);
        BossRestriction.transform.localScale = new Vector3(1f, BossRestrictionHeight, 1f);
        yield return new WaitForSeconds(1);
        Camera.GetComponent<Camera>().orthographicSize = 20;
        Camera.transform.position = new Vector3(BossLocation.transform.position.x, BossLocation.transform.position.y, -1);
        yield return new WaitForSeconds(1);
        InstantiatedBoss = Instantiate(Boss, BossLocation.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Camera.GetComponent<CameraController>().enabled = true;
        Camera.GetComponent<Camera>().orthographicSize = CameraSizeInBossBattle;
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponentInChildren<AmmusInstantiate>().enabled = true;
        Player.GetComponent<AudioSource>().clip = BossMusic;
        Player.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        InstantiatedBoss.gameObject.GetComponent<EnemyHealth>().BossHasStarted = true;
        

        
    }

    public void OnAnimationEnd()
    {
        Camera.SetActive(true);
        Camera.GetComponent<Camera>().orthographicSize = CameraSizeInBossBattle;
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponentInChildren<AmmusInstantiate>().enabled = true;
        Player.GetComponent<AudioSource>().clip = BossMusic;
        Player.GetComponent<AudioSource>().Play();
        InstantiatedBoss = Instantiate(Boss, BossLocation.transform.position, Quaternion.identity);
        InstantiatedBoss.GetComponent<EnemyHealth>().BossHasStarted = true;
        print(InstantiatedBoss.GetComponent<EnemyHealth>().BossHasStarted);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (BossAppearance == null)
            {
                StartCoroutine(ActivateBoss());
            }

            else
            {
                Player = GameObject.FindGameObjectWithTag("Player");
                Player.GetComponent<PlayerMovement>().enabled = false;
                Player.GetComponentInChildren<AmmusInstantiate>().enabled = false;
                
                Camera = GameObject.FindGameObjectWithTag("MainCamera");
                //Camera.SetActive(false);
                BossAppearance.SetTrigger(AnimationTrigger);
                
            }
        }
    }
}
