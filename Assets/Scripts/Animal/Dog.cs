using System.Collections;
using UnityEngine;

public class Dog : Animal,IDamageable
{
    private AudioSource audioSource;
    
    protected override void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySound());
        maxHealth = 30;
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

    private IEnumerator PlaySound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        StartCoroutine(PlaySound());
    }
}
