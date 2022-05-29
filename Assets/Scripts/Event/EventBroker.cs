using System;

public class EventBroker
{
    public static Action<int> UpdateScore;
    public static Action GameOver;
    public static Action<WeaponFoodType> PickupWeaponFood;
    public static Action<int> DisplayWaveSpawn;
    public static Action onGameVictory;
    public static Action onSpawnWave;
    public static Action onDisplayGameVictory;

    public static void CallUpdateScore(int score)
    {
        UpdateScore?.Invoke(score);
    }
    
    public static void CallGameOver()
    {
        GameOver?.Invoke();
    }
    public static void CallPickupWeaponFood(WeaponFoodType weaponFoodType)
    {
        PickupWeaponFood?.Invoke(weaponFoodType);
    }

    public static void CallDisplayWaveSpawn(int waveSpawn)
    {
        DisplayWaveSpawn?.Invoke(waveSpawn);
    }

    public static void CallOnGameVictory()
    {
        onGameVictory?.Invoke();
    }

    public static void CallOnSpawnWave()
    {
        onSpawnWave?.Invoke();
    }

    public static void CallDisplayGameVictory()
    {
        onDisplayGameVictory?.Invoke();
    }
}
