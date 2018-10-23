using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestoryObstacle : MonoBehaviour {

    private GameObject gameController;
    private GameObject gameOverParent;
    private GameObject gameOver;
    private ObstacleAttributes obstacle;
    private Text gameOverText;
    private bool isTheGameOver;
    public int scorePoint;
    
    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameOverParent = GameObject.Find("Canvas");
        gameOver = gameOverParent.transform.Find("GameOver").gameObject;
        isTheGameOver = false;
    }

    //Use  this for trigger
    private void OnTriggerEnter(Collider other)
    {
        GameObject tempObject = this.gameObject;
        obstacle = tempObject.GetComponent<ObstacleAttributes>();

        if (other.tag == "AddPoint")
            if (obstacle.scoreCount > 0) {
                obstacle.scoreCount -= 1;
                ScoreDisplay.scoreNumber += 10;
            }

        if (other.tag == "Boundary")
            Destroy(gameObject);

        if (other.tag == "Rocket")
        {
            isTheGameOver = true;

            if (VerifyGameOver(isTheGameOver))
            {
                FindObjectOfType<AudioControl>().Play("Explosion");
                Destroy(gameObject);
                Destroy(other.gameObject);
                gameController.SetActive(false);
                gameOver.SetActive(true);
                gameOverText = GameObject.Find("ScoreUI").GetComponent<Text>();
                gameOverText.text = "  Score: " + ScoreDisplay.scoreNumber;
            }
        }
    }

    public bool VerifyGameOver(bool isTheGameOver)
    {
        if (isTheGameOver)
            return true;
        else
            return false;
    }
}
