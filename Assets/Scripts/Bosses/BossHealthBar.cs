﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

    public GameObject BossHealthBarCanvas;
    private bool HasBeenActivated;
    public GameObject InstantiatedHealthBarCanvas;

    private void Update()
    {

        if (GetComponent<EnemyHealth>().BossHasStarted == true)
        {
            if (HasBeenActivated == false)
            {
                InstantiatedHealthBarCanvas = Instantiate(BossHealthBarCanvas, new Vector3(0, 0, 0), Quaternion.identity);
                InstantiatedHealthBarCanvas.transform.Find("HealthSlider").GetComponent<Slider>().maxValue = GetComponent<EnemyHealth>().HealthPoints;
                InstantiatedHealthBarCanvas.transform.Find("HealthSlider").GetComponent<Slider>().value = GetComponent<EnemyHealth>().HealthPoints;
                HasBeenActivated = true;
                return;
            }
        }
    }
}