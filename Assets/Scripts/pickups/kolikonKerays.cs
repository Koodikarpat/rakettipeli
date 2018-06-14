using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kolikonKerays : MonoBehaviour
{
    public int kolikkoLaskenta;
    Text KolikotText;
    Text GotACoinText;
    int viimeKolikoidenMäärä;

        void Awake()
    {
        kolikkoLaskenta = 0;
        KolikotText = GameObject.Find("KolikotText").GetComponent<Text>();
        GotACoinText = GameObject.Find("GotACoinText").GetComponent<Text>();
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

        if (kolikkoLaskenta > viimeKolikoidenMäärä)
        {
            GotACoinText.gameObject.SetActive(true);
            GotACoinText.text = "Got A Coin!";
        }

        kolikkoLaskenta = viimeKolikoidenMäärä;
    }

    void SetKolikotText()
    {
        KolikotText.text = "x " + kolikkoLaskenta;
    }
}
