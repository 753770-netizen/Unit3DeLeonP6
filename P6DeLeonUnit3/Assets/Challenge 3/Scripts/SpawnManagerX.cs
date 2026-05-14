using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Add Bomb and Money prefabs here in Inspector
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    private PlayerControllerX playerControllerScript;

    void Start()
    {
        // Fixed: The string name now matches the function name below
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    void SpawnObjects()
    {
        if (!playerControllerScript.gameOver)
        {
            Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);

            // Fixed: Length is capitalized in C#
            int index = Random.Range(0, objectPrefabs.Length);

            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }
}
