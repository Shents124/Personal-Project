using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    public static int amountOfWeapon;
    public List<GameObject> weapons;

    private int maxSpawnRange = 60;
    private int maxWeaponSpawn = 5;
    private float timeDelay = 20f;
    private float startTimeDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        startTimeDelay = timeDelay;
    }

    // Update is called once per frame
    void Update()
    {
        startTimeDelay -= Time.deltaTime;
        if (startTimeDelay <= 0 && amountOfWeapon < maxWeaponSpawn)
        {
            SpawnWeaponWave();
            amountOfWeapon++;
            startTimeDelay = timeDelay;
        }
    }

    private void SpawnWeaponWave()
    {
        int index = Random.Range(0, weapons.Count);
        Instantiate(weapons[index], GeneratePosition(), weapons[index].transform.rotation);
    }

    private Vector3 GeneratePosition()
    {
        int spawnPosX = Random.Range(-maxSpawnRange, maxSpawnRange);
        int spawnPosZ = Random.Range(-maxSpawnRange, maxSpawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 1, spawnPosZ);
        return spawnPos;
    }
}
