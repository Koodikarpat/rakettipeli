using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketBossStart : MonoBehaviour {

    private bool HasBeenActivated;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
        if (HasBeenActivated == false)
        {
            if (GetComponent<EnemyHealth>().BossHasStarted == true)
            {
                foreach (Transform child in transform)
                {
                    GameObject.FindGameObjectWithTag("BossActivation").SetActive(false);
                    foreach (Transform childitem in transform)
                    {
                        childitem.gameObject.SetActive(true);
                    }
                    HasBeenActivated = true;
                    
                    break;
                }
            }
            if (GetComponent<EnemyHealth>().HealthPoints <= 0)
            {

            }
        }
	}
}
