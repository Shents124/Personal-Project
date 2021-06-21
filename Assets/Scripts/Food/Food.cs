using UnityEngine;

public class Food : MonoBehaviour
{
    private float speed = 50f;
    [SerializeField] protected int dame;
    private string targetTag = "Animal";
    private float boundaryDestroy = 50f;

    public Vector3 moveDirection;
    public Vector3 playerPosition;

    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
        DestroyOutOfBound();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            other.GetComponent<IDamageable>().TakeDame(dame);
            gameObject.SetActive(false);
        }
    }

    private void DestroyOutOfBound()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, playerPosition);
        if (distanceFromPlayer >= boundaryDestroy)
            gameObject.SetActive(false);
    }
}