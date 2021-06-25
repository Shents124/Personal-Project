public class Stag : Animal,IDamageable
{
    protected override void OnEnable()
    {
        maxHealth = 50;
        currentHealth = maxHealth;
        base.OnEnable();
    }
    public void TakeDame(int amoutOfDame)
    {
        currentHealth -= amoutOfDame;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            EventBroker.CallUpdateScore(pointScore);
        }
    }
}
