using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHudStuff : MonoBehaviour {

    Levels levelScript;
    int aluksenLeveli;
    int viimeLeveli;

    Text levelText;
    Text levelUpText;

    void Awake () {
        levelScript = GetComponent<Levels>();
        aluksenLeveli = levelScript.level;
        viimeLeveli = 1;
        levelText = GameObject.Find("levelText").GetComponent<Text>();
        levelUpText = GameObject.Find("LevelUpText").GetComponent<Text>();
        SetLevelText();
    }

	void Update () {
        aluksenLeveli = levelScript.level;
        SetLevelText();

        if (aluksenLeveli > viimeLeveli)
        {
            levelUpText.gameObject.SetActive(true);
            levelUpText.text = "Level Up!";
        }

        viimeLeveli = aluksenLeveli;
    }

    void SetLevelText()
    {
        levelText.text = "Level: " + aluksenLeveli.ToString();
    }

}
