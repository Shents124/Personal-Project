using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public FloatVariable playerHealth;
    public FloatVariable playerMaxHealth;
    private void Update()
    {
        healthSlider.value = playerHealth.value/playerMaxHealth.value;
    }
}
