using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HäkkiovenAukaisija : MonoBehaviour {

    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            m_Animator.SetTrigger("AvaaOvi");
        }
    }
}
