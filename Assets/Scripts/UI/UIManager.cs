using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI currentWeapon;
    public TextMeshProUGUI waveSpawnAnimal;

    private int totalScore;
    private int highScore;

    private void Start()
    {
        highScore = GameManager.Instance.LoadScore();
    }

    private void OnEnable()
    {
        EventBroker.UpdateScore += UpdateScore;
        EventBroker.PickupWeaponFood += DisplayCurrentWeapon;
        EventBroker.DisplayWaveSpawn += DisplayWaveSpawn;
    }

    private void OnDisable()
    {
        EventBroker.UpdateScore -= UpdateScore;
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
    
    private void DisplayCurrentWeapon(WeaponFoodType weaponFoodType)
    {
        currentWeapon.text = "Weapon: " + weaponFoodType;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void DisplayWaveSpawn(int waveSpawn)
    {
        waveSpawnAnimal.text = "Wave " + waveSpawn;
        waveSpawnAnimal.gameObject.SetActive(true);
        Invoke(nameof(TurnOffWaveSpawn),1f);
    }

    private void TurnOffWaveSpawn()
    {
        waveSpawnAnimal.gameObject.SetActive(false);
    }
}
