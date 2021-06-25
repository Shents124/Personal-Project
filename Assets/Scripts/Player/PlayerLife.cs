using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IDamageable
{
    public int currentHealth;
    private int maxHealth = 200;
    public HealthBar healthBar;
    public bool isHasShield = false;

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDame(int amoutOfDame)
    {
        if (isHasShield)
            return;
        else
        {
            currentHealth -= amoutOfDame;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                EventBroker.CallGameOver();
                playerAnimator.SetBool("Death_b", true);
                GetComponent<PlayerController>().enabled = false;
                GetComponent<Shooting>().enabled = false;
                
                SoundManager.Instance.PlaySound(SoundManager.Instance.gameOver);
            }
        }
    }
}
