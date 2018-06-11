using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour {

    public int HealthToDisplayAt;
    public GameObject Player;

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
