using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public Canvas GameOverCanvas;
    public GameObject ExplosionSprite;
    public List<Canvas> CanvasesToDestroyWhenGameOver = new List<Canvas>();

	// Use this for initialization
	void Start () {
        foreach (Canvas item in CanvasesToDestroyWhenGameOver)
        {
            item.gameObject.SetActive(true);
        }
        //GameOverCanvas.gameObject.GetComponent<Animator>().playbackTime = 0;
        //GameOverCanvas.gameObject.GetComponent<Animator>().speed = 0;
        //GameOverCanvas.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	public void GameOverAnimation()
    {

        //GameOverCanvas.gameObject.SetActive(true);
        Instantiate(GameOverCanvas, gameObject.transform.position, Quaternion.identity);
        Instantiate(ExplosionSprite, gameObject.transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        foreach (Canvas item in CanvasesToDestroyWhenGameOver)
        {
            item.gameObject.SetActive(false);
        }
        
    }
}
