using UnityEngine;
using System.Collections.Generic;

public class SpawnPowerUpManager : MonoBehaviour
{
    public List<GameObject> powerUps;

    private int maxSpawnRange = 60;
    private int maxPowerUpSpawn = 4;
    private float timeDelay = 20f;
    private float startTimeDelay;
    
    public static int amountOfPowerUp;
    
    // Start is called before the first frame update
    private void Start()
    {
        startTimeDelay = timeDelay;
    }

    // Update is called once per frame
    private void Update()
    {
        startTimeDelay -= Time.deltaTime;
        if (startTimeDelay <= 0 && amountOfPowerUp < maxPowerUpSpawn)
        {
            SpawnPowerUpWave();
            amountOfPowerUp++;
            startTimeDelay = timeDelay;
        }
    }

    private void SpawnPowerUpWave()
    {
        int index = Random.Range(0, powerUps.Count);
        Instantiate(powerUps[index], GeneratePosition(), powerUps[index].transform.rotation);
    }

    private Vector3 GeneratePosition()
    {
        int spawnPosX = Random.Range(-maxSpawnRange, maxSpawnRange);
        int spawnPosZ = Random.Range(-maxSpawnRange, maxSpawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 1, spawnPosZ);
        return spawnPos;
    }
}
