﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{

    public int level;
    public GameObject[] Level1Barrels; //Barrelit, joita käytetään levelissä 1.
    public GameObject[] Level2Barrels; //Barrelit, joita käytetään levelissä 2.

    private void Start()
    {
        level = 1;
        foreach (GameObject item in Level2Barrels)
        {
            item.SetActive(false);
        }
    }
    public void LevelUp() { 
        if (level == 1) //Level 2.
        {
            level++;
            foreach (GameObject item in Level1Barrels)
            {
                item.SetActive(false);

            }
            foreach (GameObject item in Level2Barrels)
            {
                item.SetActive(true);
            }
            return;

        }

        if (level == 2) // Level 3. Käytetään yhtä aikaa ensimmäisen ja toisen tason barreleita.
        {
            level++;
            foreach (GameObject item in Level1Barrels)
            {
                item.SetActive(true);
            }
        }
    }
}

