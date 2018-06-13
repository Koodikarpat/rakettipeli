using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (GameObject.FindGameObjectWithTag("BossActivation").GetComponent<BossActivate>().BossHasStarted == true)
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
        }
	}
}
