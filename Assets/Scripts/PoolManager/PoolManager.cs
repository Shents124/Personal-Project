using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public Transform container;
    
    private List<GameObject> listFood;
    private int amountOfGenerate = 10;
    
    private static PoolManager _instance;
    public static PoolManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("PoolManager is null!");
            return _instance;
        }
    }
    
    private void Awake()
    {
        _instance = this;
    }

    private void OnEnable()
    {
        EventBroker.PickupWeaponFood += ChangeWeaponFood;
    }

    private void OnDisable()
    {
        EventBroker.PickupWeaponFood -= ChangeWeaponFood;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Generate list contains 10 game objects
        listFood = GenerateFood(amountOfGenerate,foodPrefabs[0]);
    }

    private List<GameObject> GenerateFood(int amount, GameObject foodPrefab)
    {
        List<GameObject> newList = new List<GameObject>();
        for (int i = 0; i < amount; i++)
        {
            GameObject food = Instantiate(foodPrefab, container, true);
            food.SetActive(false);
            newList.Add(food);
        }
        return newList;
    }

    private void DestroyFood()
    {
        foreach (var food in listFood)
        {
            Destroy(food);
        }
    }

    public GameObject RequestFood()
    {
        foreach (GameObject food in listFood)
        {
            if (!food.gameObject.activeInHierarchy)
            {
                food.SetActive(true);
                return food;
            }
        }

        GameObject newFood = Instantiate(listFood[0], container, true);
        listFood.Add(newFood);
        return newFood;
    }

    private GameObject GetFoodPrefabs(WeaponFoodType weaponFoodType)
    {
        switch (weaponFoodType)
        {
            case WeaponFoodType.Apple: return foodPrefabs[0];
            case WeaponFoodType.Cookie: return foodPrefabs[1];
            case WeaponFoodType.Sandwich: return foodPrefabs[2];
            default: return null;
        }
    }
    
    private void ChangeWeaponFood(WeaponFoodType weaponFoodType)
    {
        DestroyFood();
        listFood = GenerateFood(amountOfGenerate, GetFoodPrefabs(weaponFoodType));
    }
}
