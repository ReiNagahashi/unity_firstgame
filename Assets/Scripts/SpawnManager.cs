using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangeX = 10;
    private float spawnRangeZ = 20;
    private float startDelay = 2.0f;
    private float delayTime = 1.5f;
    public GameObject[] spawnPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) SpawnRandomAnimal();        
    }

    void SpawnRandomAnimal()
    {

        int animalIndex = Random.Range(0, spawnPrefabs.Length);
        Vector3 spawnAnimalPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);

        Instantiate(spawnPrefabs[animalIndex], spawnAnimalPosition, spawnPrefabs[animalIndex].transform.rotation);
    }
}
