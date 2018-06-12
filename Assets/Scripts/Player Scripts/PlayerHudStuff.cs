using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHudStuff : MonoBehaviour {

    Levels levelScript;
    int aluksenLeveli;
    int viimeLeveli;

    public Text levelText;
    public Text levelUpText;
    public Text levelDownText;

    void Start () {
        levelScript = GetComponent<Levels>();
        aluksenLeveli = levelScript.level;
        SetLevelText();
        viimeLeveli = 1;
    }

	void Update () {
        aluksenLeveli = levelScript.level;
        SetLevelText();

        if (aluksenLeveli > viimeLeveli)
        {
            levelUpText.gameObject.SetActive(true);
            levelUpText.text = "Level Up!";
        }

        if (aluksenLeveli < viimeLeveli)
        {
            levelDownText.gameObject.SetActive(true);
            levelDownText.text = "Level Down ;C";
        }

        viimeLeveli = aluksenLeveli;
    }

    void SetLevelText()
    {
        levelText.text = "Level: " + aluksenLeveli.ToString();
    }

}
