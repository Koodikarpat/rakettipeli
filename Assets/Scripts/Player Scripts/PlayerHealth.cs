using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int playerHealth;
    int viimePlayerHealth;

    Text healthUpText;

    private void Awake()
    {
        playerHealth = 3;
        healthUpText = GameObject.Find("HealthUpText").GetComponent<Text>();
        viimePlayerHealth = 3;
    }

    private void Update()
    {
        if(playerHealth > viimePlayerHealth)
        {
//<<<<<<< Updated upstream
            healthUpText.gameObject.SetActive(true);
            healthUpText.text = ("Health Up!");
//=======
            playerHealth++;
//           Destroy(collision.gameObject);
//>>>>>>> Stashed changes
        }

        viimePlayerHealth = playerHealth;
    }
}
