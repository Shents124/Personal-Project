using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    public Image staminaFill;
    
    public void UpdateStamina(float playerStamina,float maxPlayerStamina)
    {
        float stamina = playerStamina / maxPlayerStamina;
        staminaFill.fillAmount = stamina;
    }
}
