using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public static int amountOfAnimal;
    private int amountOfAnimalDefaut = 5;
    public List<GameObject> listAnimals;
    public Transform playerPosition;
    private int spawnRange = 60;
    private float timeDelaySpawn = 1f;
    private float startTimeDelay;
    
    private void Awake()
    {
        amountOfAnimal = amountOfAnimalDefaut;
        startTimeDelay = timeDelaySpawn;
    }

    // Start is called before the first frame update
    private void Start()
    {
        SpawnAnimal(amountOfAnimal);
    }

    // Update is called once per frame
    private void Update()
    {
        if (amountOfAnimal == 0)
        {
            startTimeDelay -= Time.deltaTime;
            if (startTimeDelay <= 0)
            {
                startTimeDelay = timeDelaySpawn;
                amountOfAnimalDefaut++;
                amountOfAnimal = amountOfAnimalDefaut;
                SpawnAnimal(amountOfAnimal);
            }
        }
    }

    private void SpawnAnimal(int amountOfAnimal)
    {
        for (int i = 0; i < amountOfAnimal; i++)
        {
            int x = Random.Range(0, listAnimals.Count);
            GameObject animalPrefab =
                Instantiate(listAnimals[x], GenerateSpawnPosition(), listAnimals[x].transform.rotation);
            animalPrefab.GetComponent<Animal>().playerPosition = playerPosition;
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        int spawnPosX = Random.Range(-spawnRange, spawnRange);
        int spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
}
