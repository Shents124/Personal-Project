using UnityEngine;

public class Pickup : MonoBehaviour
{
    public WeaponFoodType weaponFoodType;
    private string weaponTag = "WeaponPickup";
    private string powerupTag = "Powerup";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(weaponTag))
        {
            weaponFoodType = other.GetComponent<WeaponFoodPickup>().weaponFoodType;
            Debug.Log(weaponFoodType);
            Destroy(other.gameObject);
            EventBroker.CallPickupWeaponFood(weaponFoodType);
        }
    }
}
