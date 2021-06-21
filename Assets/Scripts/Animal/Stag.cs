using UnityEngine;

public class Stag : Animal,IDamageable
{
    private void OnEnable()
    {
        maxHealth = 50;
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
