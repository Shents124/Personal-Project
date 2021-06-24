using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnAnimal : MonoBehaviour
{
    public static int amountOfAnimal;
    private int amountOfAnimalDefault = 5;
    public GameObject dragon;
    public List<GameObject> listAnimals;
    public Transform playerTransform;
    private int maxSpawnRange = 60;
    private float timeDelaySpawn = 1f;
    private float startTimeDelay;
    private int waveSpawn;

    public static bool isSpawnDragon = false;
    private void Awake()
    {
        amountOfAnimal = amountOfAnimalDefault;
        startTimeDelay = timeDelaySpawn;
    }

    // Start is called before the first frame update
    private void Start()
    {
        SpawnAnimalWave(amountOfAnimal);
        waveSpawn = 1;
        EventBroker.CallDisplayWaveSpawn(waveSpawn);
        isSpawnDragon = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (amountOfAnimal == 0)
        {
            startTimeDelay -= Time.deltaTime;
            if (startTimeDelay <= 0)
            {
                waveSpawn++;
                startTimeDelay = timeDelaySpawn;
                amountOfAnimalDefault++;
                amountOfAnimal = amountOfAnimalDefault;
                SpawnAnimalWave(amountOfAnimalDefault);
                Debug.Log(amountOfAnimalDefault);
                EventBroker.CallDisplayWaveSpawn(waveSpawn);
                if (waveSpawn > 0 && waveSpawn % 3 == 0 && isSpawnDragon == false)
                {
                    SpawnDragonWave();
                    isSpawnDragon = true;
                }
            }
        }
    }

    private void SpawnAnimalWave(int amountOfAnimal)
    {
        for (int i = 0; i < amountOfAnimal; i++)
        {
            int x = Random.Range(0, listAnimals.Count);
            GameObject animalPrefab =
                Instantiate(listAnimals[x], GenerateSpawnPosition(), listAnimals[x].transform.rotation);
            animalPrefab.GetComponent<Animal>().playerTransform = playerTransform;
        }
    }

    private void SpawnDragonWave()
    {
        GameObject dragonInstantiate = Instantiate(dragon, GenerateSpawnPosition(), dragon.transform.rotation);
        dragonInstantiate.GetComponent<Animal>().playerTransform = playerTransform;
    }

    private Vector3 GenerateSpawnPosition()
    {
        int spawnPosX = Random.Range(-maxSpawnRange, maxSpawnRange);
        int spawnPosZ = Random.Range(-maxSpawnRange, maxSpawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
}