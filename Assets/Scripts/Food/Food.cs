using System;
using UnityEngine;

public class Food : MonoBehaviour
{
    private float speed = 50f;
    [SerializeField] protected int dame;
    private string targetTag = "Animal";
    private float boundaryDestroy = 50f;
    [SerializeField] private GameObject hitEffect;

    public Vector3 moveDirection;
    public Vector3 playerPosition;

    private void OnEnable()
    {
        //foodRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
        DestroyOutOfBound();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDame(dame);
            gameObject.SetActive(false);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect,0.5f);
        }
    }

    private void DestroyOutOfBound()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, playerPosition);
        if (distanceFromPlayer >= boundaryDestroy)
            gameObject.SetActive(false);
    }
}