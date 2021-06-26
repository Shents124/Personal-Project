using UnityEngine;

public class PlayerLife : MonoBehaviour, IDamageable
{
    public int currentHealth;
    public HealthBar healthBar;
    public bool isHasShield = false;

    private int maxHealth = 200;
    
    private Animator playerAnimator;
    
    private static readonly int DeathB = Animator.StringToHash("Death_b");

    // Start is called before the first frame update
    private void Start()
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

    public void TakeDame(int amountOfDame)
    {
        if (isHasShield)
            return;
        else
        {
            currentHealth -= amountOfDame;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                EventBroker.CallGameOver();
                playerAnimator.SetBool(DeathB, true);
                GetComponent<PlayerController>().enabled = false;
                GetComponent<Shooting>().enabled = false;
                
                SoundManager.Instance.PlaySound(SoundManager.Instance.gameOver);
            }
        }
    }
}
