using System;

public class EventBroker
{
    public static Action<int> UpdateScore;
    public static Action UpdateCountAnimal;
    public static Action GameOver;
    public static Action<WeaponFoodType> PickupWeaponFood;

    public static void CallUpdateScore(int score)
    {
        UpdateScore?.Invoke(score);
    }
    public static void CallUpdateCountAnimal()
    {
        UpdateCountAnimal?.Invoke();
    }

    public static void CallGameOver()
    {
        GameOver?.Invoke();
    }
    public static void CallPickupWeaponFood(WeaponFoodType weaponFoodType)
    {
        PickupWeaponFood?.Invoke(weaponFoodType);
    }
}
