public class Horse : Animal,IDamageable
{
    protected override void OnEnable()
    {
        maxHealth = 50;
        currentHealth = maxHealth;
        base.OnEnable();
    }
    public void TakeDame(int amountOfDame)
    {
        currentHealth -= amountOfDame;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            EventBroker.CallUpdateScore(pointScore);
        }
    }
}
