using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kolikonKerays : MonoBehaviour
{
    public int kolikkoLaskenta;
    public Text KolikotText;

        void Start()
    {
        kolikkoLaskenta = 0;
    }

    void OnTriggerEnter2D(Collider2D mihinTormattiin)
    {
        if (mihinTormattiin.CompareTag("kolikko"))
        {
            kolikkoLaskenta = kolikkoLaskenta + 1;
            mihinTormattiin.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        SetKolikotText();
    }

    void SetKolikotText()
    {
        KolikotText.text = "x " + kolikkoLaskenta;
    }
}
