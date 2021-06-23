using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private int currentHealth;
    private int maxHealth = 200;
    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Animal"))
        {
            TakeDame();
        }
    }

    private void TakeDame()
    {
        currentHealth -= 5;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            EventBroker.CallGameOver();
        }
    }
}