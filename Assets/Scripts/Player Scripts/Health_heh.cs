﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_heh : MonoBehaviour {

    float m_time = 0.0f;
    public int odotusAika;
    Text huhuu;

    private void Start()
    {
        huhuu = gameObject.GetComponent<Text>();
        huhuu.enabled = false;
    }

    void Update()
    {
        if (huhuu.enabled==true)
        {
            m_time += Time.deltaTime;

            if (m_time >= odotusAika)
            {
                m_time = 0.0f;

                huhuu.enabled = false;
            }
        }

        else
        {
            m_time += Time.deltaTime;

            if (m_time >= odotusAika)
            {
                m_time = 0.0f;

                huhuu.enabled = true;
            }
        }
    }
}