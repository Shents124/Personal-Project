public class Cow : Animal
{
    protected override void OnEnable()
    {
        maxHealth = 80;
        currentHealth = maxHealth;
        base.OnEnable();
    }
}
