using UnityEngine;

public class Dog : Animal,IDamageable
{
    private void OnEnable()
    {
        maxHealth = 30;
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
