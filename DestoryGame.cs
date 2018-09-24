using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestoryGame : MonoBehaviour {

    public Text gameOverText;
    private bool isTheGameOver;
    public GameObject gameController;

    // Use this for initialization
    void Start () {
        isTheGameOver = false;
       // gameOverText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    //Use  this for trigger
    private void OnTriggerEnter(Collider other)
    {
        isTheGameOver = true;
        gameOverText.text = "Game Over!!";
        Destroy(gameObject);
        gameController.SetActive(false);
        
    }

    public bool VerifyGameOver(bool isTheGameOver)
    {
        if (isTheGameOver)
            return true;
        else
            return false;
    }

    
}
