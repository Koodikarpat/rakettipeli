using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public Canvas GameOverCanvas;
    public GameObject ExplosionSprite;

	// Use this for initialization
	void Start () {
        GameOverCanvas.gameObject.GetComponent<Animator>().playbackTime = 0;
        GameOverCanvas.gameObject.GetComponent<Animator>().speed = 0;
    }
	
	// Update is called once per frame
	public void GameOverAnimation()
    {
        ExplosionSprite.transform.position = gameObject.transform.position;
        gameObject.SetActive(false);
        ExplosionSprite.GetComponent<Animator>().Play("Explosion");
        GameOverCanvas.gameObject.GetComponent<Animator>().speed = 1;
    }
}
