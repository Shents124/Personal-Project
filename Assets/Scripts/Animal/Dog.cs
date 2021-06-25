using System.Collections;
using UnityEngine;

public class Dog : Animal
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

    IEnumerator PlaySound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        StartCoroutine(PlaySound());
    }
}
