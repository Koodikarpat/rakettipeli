using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject GameOverCanvas;
    public GameObject ExplosionSprite;
    public string[] tuhottavatObjectit;
    List<GameObject> CanvasesToDestroyWhenGameOver = new List<GameObject>();

    //Tämä scripti spawnaa GameOver-näytön pelaajan kuollessa ja tuhoaa kaikki annetut canvasit.
    
    void Start () {
        foreach (string tuhottavanObjectinNimi in tuhottavatObjectit)
        {
            CanvasesToDestroyWhenGameOver.Add(GameObject.Find(tuhottavanObjectinNimi));
        }

        foreach (GameObject item in CanvasesToDestroyWhenGameOver)
        {
            item.gameObject.SetActive(true);
        }
        //GameOverCanvas.gameObject.GetComponent<Animator>().playbackTime = 0;
        //GameOverCanvas.gameObject.GetComponent<Animator>().speed = 0;
        //GameOverCanvas.gameObject.SetActive(false);
    }
	
	public void GameOverAnimation()
    {

        //GameOverCanvas.gameObject.SetActive(true);
        Instantiate(GameOverCanvas, gameObject.transform.position, Quaternion.identity);
        Instantiate(ExplosionSprite, gameObject.transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        foreach (GameObject item in CanvasesToDestroyWhenGameOver)
        {
            item.gameObject.SetActive(false);
        }
        
    }
}
