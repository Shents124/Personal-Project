using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    public TextMeshProUGUI animalCount;

    public TextMeshProUGUI currentWeapon;
    public TextMeshProUGUI waveSpawnAnimal;

    private int totalScore;
    private int totalCount;
    private int highScore;

    private void Start()
    {
        highScore = GameManager.Instance.LoadScore();
    }

    private void OnEnable()
    {
        EventBroker.UpdateScore += UpdateScore;
        EventBroker.UpdateCountAnimal += UpdateCountAnimal;
        EventBroker.PickupWeaponFood += DisplayCurrentWeapon;
        EventBroker.DisplayWaveSpawn += DisplayWaveSpawn;
    }

    private void OnDisable()
    {
        EventBroker.UpdateScore -= UpdateScore;
        EventBroker.UpdateCountAnimal -= UpdateCountAnimal;
        EventBroker.PickupWeaponFood -= DisplayCurrentWeapon;
        EventBroker.DisplayWaveSpawn -= DisplayWaveSpawn;
    }

    private void UpdateScore(int point)
    {
        totalScore += point;
        score.text = "Score: " + totalScore;
        if (totalScore >= highScore)
        {
            highScore = totalScore;
            GameManager.Instance.SaveScore(highScore);
        }
    }

    private void UpdateCountAnimal()
    {
        totalCount++;
        animalCount.text = "Count: " + totalCount;
    }

    private void DisplayCurrentWeapon(WeaponFoodType weaponFoodType)
    {
        currentWeapon.text = "Weapon: " + weaponFoodType;
    }

    private void DisplayWaveSpawn(int waveSpawn)
    {
        waveSpawnAnimal.text = "Wave " + waveSpawn;
        waveSpawnAnimal.gameObject.SetActive(true);
        Invoke("TurnOffWaveSpawn",1);
    }

    private void TurnOffWaveSpawn()
    {
        waveSpawnAnimal.gameObject.SetActive(false);
    }
}
