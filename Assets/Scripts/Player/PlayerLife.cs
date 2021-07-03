using UnityEngine;

public class PlayerLife : MonoBehaviour, IDamageable
{
    public FloatVariable currentHealth;
    public FloatReference maxHealth;
    public ParticleSystem shieldEffect;
    public HealthBar healthBar;
    public bool isHasShield = false;
    
    private Animator playerAnimator;
    
    private static readonly int DeathB = Animator.StringToHash("Death_b");

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth.value = maxHealth.Value;
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentHealth.value >= maxHealth.Value)
        {
            currentHealth.value = maxHealth.Value;
        }
    }

    public void TakeDame(int amountOfDame)
    {
        if (isHasShield)
            return;
        else
        {
            currentHealth.value -= amountOfDame;
            if (currentHealth.value <= 0)
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
