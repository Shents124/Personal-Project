using UnityEngine;

public class Food : MonoBehaviour
{
    public Vector3 moveDirection;
    public Vector3 playerPosition;
    public FoodData foodData;
    [SerializeField] protected int dame;
    
    private void FixedUpdate()
    {
        transform.Translate(moveDirection * (foodData.speed.Value * Time.deltaTime));
        DestroyOutOfBound();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(foodData.targetTag))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDame(dame);
            gameObject.SetActive(false);
            GameObject effect = Instantiate(foodData.hitEffect, transform.position, Quaternion.identity);
            Destroy(effect,0.5f);
            
            SoundManager.Instance.PlaySound(SoundManager.Instance.hitSound);
        }
    }

    private void DestroyOutOfBound()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, playerPosition);
        if (distanceFromPlayer >= foodData.boundaryDestroy.Value)
            gameObject.SetActive(false);
    }
}