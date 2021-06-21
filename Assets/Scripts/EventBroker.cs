
using System;

public class EventBroker
{
    public static Action<int> UpdateScore;
    public static Action<WeaponFoodType> PickupWeaponFood;

    public static void CallUpdateScore(int score)
    {
        UpdateScore?.Invoke(score);
    }

    public static void CallPickupWeaponFood(WeaponFoodType weaponFoodType)
    {
        PickupWeaponFood?.Invoke(weaponFoodType);
    }
}
