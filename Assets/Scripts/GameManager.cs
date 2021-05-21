using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables
    private float minWait = 0.92f;
    private float maxWait = 2f;
    private bool isSpawning = false;
    public GameObject[] obstaclePrefabs;
    private CharacterController2D playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // setting variables
        playerControllerScript = GameObject.Find("Player").GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if currently spawning = false spawn an object within the min / max wait
        if (!isSpawning && !playerControllerScript.isGameOver && playerControllerScript.hasGameStarted)
        {
            float timer = Random.Range(minWait, maxWait);
            Invoke("SpawnObstacles", timer);
            isSpawning = true;
        }
    }

    /** SPAWN MECHANICS **/
    private void SpawnObstacles()
    {
        // random number to select random obstacle
        int randNumAll = Random.Range(0, 6);

        // creates obstacle
        Instantiate(obstaclePrefabs[randNumAll], new Vector3(17, -3.81f, 0), transform.rotation);

        // allows another obstacle to spawn
        isSpawning = false;
    }
    /** END **/

}
