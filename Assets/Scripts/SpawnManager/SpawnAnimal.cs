using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnAnimal : MonoBehaviour
{
    private int amountOfAnimalSpawn= 5;
    
    public GameObject dragon;
    public List<GameObject> listAnimals;
    public Transform playerTransform;
    
    private int maxSpawnRange = 60;
    private int waveSpawn;

    public static bool isSpawnDragon = false;

    private AudioSource audioSource;
    
    private void OnEnable()
    {
        EventBroker.GameOver += StopPlayMusic;
    }

    private void OnDisable()
    {
        EventBroker.GameOver -= StopPlayMusic;
    }

    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SpawnAnimalWave(amountOfAnimalSpawn);
        waveSpawn = 1;
        EventBroker.CallDisplayWaveSpawn(waveSpawn);
        isSpawnDragon = false;
    }

    // Update is called once per frame
    private void Update()
    {
        int animalCount = FindObjectsOfType<Animal>().Length;
        if (animalCount <= 0)
        {
            amountOfAnimalSpawn++;
            if (amountOfAnimalSpawn >= 20)
                amountOfAnimalSpawn = 20;
            waveSpawn++;
            SpawnAnimalWave(amountOfAnimalSpawn);
            EventBroker.CallDisplayWaveSpawn(waveSpawn);
            
            if (waveSpawn > 0 && waveSpawn % 3 == 0 && isSpawnDragon == false)
            {
                SpawnDragonWave();
                isSpawnDragon = true;
            }
        }
    }

    private void SpawnAnimalWave(int amountOfAnimal)
    {
        SoundManager.Instance.PlayBattleSound(audioSource,SoundManager.Instance.GetRandomBattleSound());
        
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
        SoundManager.Instance.PlayBattleSound(audioSource,SoundManager.Instance.bossAppearSound);
        
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

    private void StopPlayMusic()
    {
        audioSource.Stop();
    }
}