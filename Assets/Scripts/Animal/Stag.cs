public class Stag : Animal
{
    protected override void OnEnable()
    {
        maxHealth = 50;
        currentHealth = maxHealth;
        base.OnEnable();
    }
}
