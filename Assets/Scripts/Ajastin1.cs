using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ajastin1 : MonoBehaviour {

    bool m_supposedToCheckTime = false;
    float m_time = 0.0f;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameObject.activeSelf)
        {
                m_time += 0.01f;

                if (m_time >= 2.0f)
                {
                    m_time = 0.0f;
                    m_supposedToCheckTime = false;

                    gameObject.SetActive(false);
                }
            
        }
    }
}
