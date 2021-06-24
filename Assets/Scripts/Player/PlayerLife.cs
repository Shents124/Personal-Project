using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Animal") && isHasShield == false)
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
            playerAnimator.SetBool("Death_b",true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<Shooting>().enabled = false;
        }
    }
}
