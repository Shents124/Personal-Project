using System;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] protected float speed;
    public Transform playerPosition;

    protected int currentHealth;
    protected int maxHealth;
    private Rigidbody _animalRb;

    private float timeDelay;

    private void OnEnable()
    {
        timeDelay = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animalRb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        // Look at player
        this.transform.LookAt(playerPosition);
    }

    private void FixedUpdate()
    {
        timeDelay -= Time.deltaTime;
        if (timeDelay <= 0)
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 direction = (playerPosition.position - transform.position).normalized;
        // Add velocity
        _animalRb.velocity = direction * speed;
    }
}
