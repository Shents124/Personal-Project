using UnityEngine;

public class Cow : Animal,IDamageable
{
    private void OnEnable()
    {
        maxHealth = 80;
        currentHealth = maxHealth;
    }

    public void TakeDame(int amoutOfDame)
    {
        currentHealth -= amoutOfDame;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SpawnManager.amountOfAnimal--;
        }
    }
}
