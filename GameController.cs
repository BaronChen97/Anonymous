using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Quaternion spawnRotation = Quaternion.identity;     
                Instantiate(obstacle, obstaclePosition, spawnRotation);
                // Wating [spawnWait] second then generate next obstacle
                yield return new WaitForSeconds(spawnWait);
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
