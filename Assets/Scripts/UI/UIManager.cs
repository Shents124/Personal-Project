using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI currentWeapon;
    public TextMeshProUGUI waveSpawnAnimal;

    private int totalScore;
    private int highScore;
    private string maxScore = "9999999";
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
        switch (totalScore.ToString().Length)
        {
            case 1: score.text = "000000" + totalScore;
                break;
            case 2: score.text = "00000" + totalScore;
                break;
            case 3: score.text = "0000" + totalScore;
                break;
            case 4: score.text = "000" + totalScore;
                break;
            case 5: score.text = "00" + totalScore;
                break;
            case 6: score.text = "0" + totalScore;
                break;
            case 7: score.text = totalScore.ToString();
                break;
            default: score.text = maxScore;
                break;
        }
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
