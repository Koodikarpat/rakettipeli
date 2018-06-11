using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ajastin1 : MonoBehaviour {

    float m_time = 0.0f;
    public float odotusAika;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
                m_time += Time.deltaTime;

                if (m_time >= odotusAika)
                {
                    m_time = 0.0f;

                    gameObject.SetActive(false);
                }
        }
    }
}
