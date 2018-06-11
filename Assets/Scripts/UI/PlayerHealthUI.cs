using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {

    public int HealthToDisplayAt;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void CheckPlayerHealth()
    {
        if (HealthToDisplayAt > Player.GetComponent<PlayerHealth>().playerHealth)
        {
            GetComponent<Image>().enabled = false;
        }
    }

	void Update () {
        CheckPlayerHealth();
	}
}
