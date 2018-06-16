using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketBossStart : MonoBehaviour
{

    private bool HasBeenActivated;

    //Tämä scripti sisältää kaikki funktiot, jotka pyöritetään bossin syntyessä 

    private void Start()
    {
        HasBeenActivated = false;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (HasBeenActivated == false)
        {
            if (GetComponent<EnemyHealth>().BossHasStarted == true)
            {
                print("Spawned boss");
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }
                GameObject.FindGameObjectWithTag("BossActivation").SetActive(false);
                HasBeenActivated = true;
            }
        }
    }
}