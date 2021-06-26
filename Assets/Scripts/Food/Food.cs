using UnityEngine;

public class Food : MonoBehaviour
{
    public Vector3 moveDirection;
    public Vector3 playerPosition;
    
    [SerializeField] protected int dame;
    [SerializeField] private GameObject hitEffect;
    
    private float speed = 50f;
    private string targetTag = "Animal";
    private float boundaryDestroy = 50f;
    
    private void FixedUpdate()
    {
        transform.Translate(moveDirection * (speed * Time.deltaTime));
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
            
            SoundManager.Instance.PlaySound(SoundManager.Instance.hitSound);
        }
    }

    private void DestroyOutOfBound()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, playerPosition);
        if (distanceFromPlayer >= boundaryDestroy)
            gameObject.SetActive(false);
    }
}