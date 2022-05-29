public class Cow : Animal,IDamageable
{
    protected override void OnEnable()
    {
        maxHealth = dataAnimal.maxHealth.Value;
        currentHealth = maxHealth;
        base.OnEnable();
    }
    public void TakeDame(int amountOfDame)
    {
        if(animalHealthBar.gameObject.activeInHierarchy == false)
            animalHealthBar.gameObject.SetActive(true);
        currentHealth -= amountOfDame;
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            EventBroker.CallUpdateScore(dataAnimal.pointScore);
        }
    }
}
