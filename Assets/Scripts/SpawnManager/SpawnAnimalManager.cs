using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnAnimalManager : MonoBehaviour
{
    public GameObject dragon;
    public List<GameObject> listAnimals;
    public Transform playerTransform;
    public GameObject key;

    [SerializeField] private int amountOfAnimalSpawn = 5;
    private const int MaxSpawnRange = 60;
    private int waveSpawn;
    private int animalCount = 0;

    private void OnEnable()
    {
        EventBroker.onSpawnWave += Spawn;
    }

    private void OnDisable()
    {
        EventBroker.onSpawnWave -= Spawn;
    }

    // Start is called before the first frame update
    private void Start()
    {
        key.SetActive(false);
        SpawnAnimalWave();
        waveSpawn = 1;
        EventBroker.CallDisplayWaveSpawn(waveSpawn);
    }

    // Update is called once per frame
    private void Update()
    {
        animalCount = transform.childCount;
        
        if (animalCount <= 0 && waveSpawn < 5)
        {
           key.SetActive(true);
        }
    }

    private void Spawn()
    {
        key.SetActive(false);
        
        if (IsSpawnDragonWave())
        {
            SpawnDragonWave();
        }
        else
        {
            SpawnAnimalWave();
        }
        
        EventBroker.CallDisplayWaveSpawn(waveSpawn);
    }
    
    private void SpawnAnimalWave()
    {
        if (waveSpawn >= 1)
        {
            amountOfAnimalSpawn++;
            waveSpawn++;
        }
            
        
        SoundManager.Instance.PlayBattleSound(SoundManager.Instance.GetRandomBattleSound());

        for (int i = 0; i < amountOfAnimalSpawn; i++)
        {
            int x = Random.Range(0, listAnimals.Count);
            GameObject animalPrefab =
                Instantiate(listAnimals[x], GenerateSpawnPosition(), listAnimals[x].transform.rotation);
            animalPrefab.GetComponent<Animal>().playerTransform = playerTransform;
            animalPrefab.transform.parent = this.transform;
        }
    }

    private void SpawnDragonWave()
    {
        waveSpawn++;
        SoundManager.Instance.PlayBattleSound(SoundManager.Instance.bossAppearSound);

        GameObject dragonInstantiate = Instantiate(dragon, GenerateSpawnPosition(), dragon.transform.rotation);
        dragonInstantiate.GetComponent<Animal>().playerTransform = playerTransform;
    }

    private Vector3 GenerateSpawnPosition()
    {
        int spawnPosX = Random.Range(-MaxSpawnRange, MaxSpawnRange);
        int spawnPosZ = Random.Range(-MaxSpawnRange, MaxSpawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }

    private bool IsSpawnDragonWave()
    {
        return waveSpawn == 4;
    }
}