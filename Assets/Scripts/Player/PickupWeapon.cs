using UnityEngine;

public class PickupWeapon : MonoBehaviour
{
    public WeaponFoodType weaponFoodType;
    private string weaponTag = "WeaponPickup";
    private float timeCountDownCookie = 15f;
    private float timeCountDownSandwich = 10f;

    private void Update()
    {
        if(weaponFoodType == WeaponFoodType.Cookie)
            UsingCookieWeapon();
        if(weaponFoodType == WeaponFoodType.Sandwich)
            UsingSandwichWeapon();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(weaponTag))
        {
            weaponFoodType = other.GetComponent<WeaponFoodPickup>().weaponFoodType;
            Destroy(other.gameObject);
            EventBroker.CallPickupWeaponFood(weaponFoodType);
            SpawnWeapon.amountOfWeapon--;
        }
    }

    private void UsingCookieWeapon()
    {
        timeCountDownCookie -= Time.deltaTime;
        if (timeCountDownCookie <= 0)
        {
            UsingAppleWeapon();
            timeCountDownCookie = 15f;
        }
    }

    private void UsingSandwichWeapon()
    {
        timeCountDownSandwich -= Time.deltaTime;
        if (timeCountDownSandwich <= 0)
        {
            UsingAppleWeapon();
            timeCountDownSandwich = 10f;
        }
    }

    private void UsingAppleWeapon()
    {
        weaponFoodType = WeaponFoodType.Apple;
        EventBroker.CallPickupWeaponFood(weaponFoodType);
    }
}
