using UnityEngine;
using UnityEngine.UI;
public class AnimalHealthBar : MonoBehaviour
{
    public Slider animalHealthBarSlider;
    
    public void SetMaxHealth(float maxHealth)
    {
        animalHealthBarSlider.maxValue = maxHealth;
        animalHealthBarSlider.value = maxHealth;
    }

    public void UpdateHealth(float currentHealth)
    {
        animalHealthBarSlider.value = currentHealth;
    }
}
