using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject obstacle;         // Refer to the object from Unity
    public Vector3 spawnPosition;       // The set up the spawn position for the obstacle spawn position
    public Vector3 obstaclePosition;    // The Vector3 position of the obstacle
    public int obstacleCount;           // Spawn in total number
    public float spawnWait;             // Waiting time for next spawn

    private void Start()
    {
        // Call SpawnWaves at the start
        StartCoroutine (SpawnWaves());
        FindObjectOfType<AudioControl>().Play("BG");
    }


    // To spawn obstacles waves
    IEnumerator SpawnWaves()
    {
        // Generate a while loop to achieve infinite generate the obstacles
        while (true)
        {
            // The total number of obstacle generate the game
            for (int i = 0; i < obstacleCount; i++)
            {
                
                obstaclePosition = randomSpawPosition(spawnPosition);
                // Set no ratation for the obstacle 
                Instantiate(obstacle, obstaclePosition, Quaternion.Euler(new Vector3(90, 0, 0)));
                // Wating [spawnWait] second then generate next obstacle
                if (ScoreDisplay.scoreNumber <= 100)         // when socre <=100
                {
                    yield return new WaitForSeconds(spawnWait);    //spawnWait initializes to 0.8 in speed for each spawn

                }
                else if (ScoreDisplay.scoreNumber > 100 && ScoreDisplay.scoreNumber <= 500)  //score between 110 and 500
                {
                    yield return new WaitForSeconds((float)(spawnWait - 0.2));     // spawnwait = 0.8 - 0.2 = 0.6

                }
                else if (ScoreDisplay.scoreNumber > 500 && ScoreDisplay.scoreNumber <= 1000)   //score between 510 and 1000
                {
                    yield return new WaitForSeconds((float)(spawnWait - 0.3));  // spawnwait = 0.8 - 0.3 = 0.5
                }

                else if (ScoreDisplay.scoreNumber > 1000 && ScoreDisplay.scoreNumber <= 1500)   //score between 1100 and 1500
                {
                    yield return new WaitForSeconds((float)(spawnWait - 0.4));  // spawnwait = 0.8 - 0.4 = 0.4
                }

                else               // when scores > 1500
                {
                    yield return new WaitForSeconds((float)(spawnWait - 0.5));  // spawnwait = 0.8 - 0.5 = 0.3
                }
            }
        }
    }

    // Set up a random spawn position
    // The x mean left and right, that mean negative x is the left side
    // The positive x is the right side, since it is 2D y should be 0
    // The z mean high of it, and it should bigger than the map
    public Vector3 randomSpawPosition(Vector3 spawnValues) 
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

        return spawnPosition;
    }
}
