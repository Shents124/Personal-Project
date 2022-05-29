using System;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] protected DataAnimal dataAnimal;
    
    protected float currentHealth;
    protected float maxHealth;
    [SerializeField] protected float healthDragon = 300;
    protected AnimalHealthBar animalHealthBar;
    
    private Vector3 direction;
    private Rigidbody animalRb;
    private float timeDelay;
    
    protected virtual void OnEnable()
    {
        timeDelay = 1.5f;
        EventBroker.GameOver += StopFollowingPlayer;
        
        animalHealthBar = gameObject.GetComponentInChildren<AnimalHealthBar>();
        animalHealthBar.SetMaxHealth(maxHealth);
        if(maxHealth < healthDragon)
            animalHealthBar.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        EventBroker.GameOver -= StopFollowingPlayer;
    }

    private void OnDestroy()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponentInChildren<Rigidbody>();
    }

    protected virtual void Update()
    {
        // Look at player
        this.transform.LookAt(playerTransform);
        animalHealthBar.UpdateHealth(currentHealth);
    }

    private void FixedUpdate()
    {
        timeDelay -= Time.deltaTime;
        if (timeDelay <= 0)
        {
            Move();
        }
    }

    protected virtual void Move()
    {
        direction = (playerTransform.position - transform.position).normalized;
        // Add velocity
        animalRb.velocity = direction * dataAnimal.speed;
    }
    
    private void StopFollowingPlayer()
    {
        gameObject.SetActive(false);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDame(dataAnimal.dame);
        }
    }
}
