public class Dog : Animal
{
    protected override void OnEnable()
    {
        maxHealth = 30;
        currentHealth = maxHealth;
        base.OnEnable();
    }
}
