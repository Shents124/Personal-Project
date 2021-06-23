using UnityEngine;

public class Dragon : Animal
{
    private float maxDistanceRange = 20f;
    private float minDistanceRange = 15f;
    private float runSpeed = 18f;
    private float flySpeed = 22f;
    
    private Animator dragonAnimator;
    
    protected override void OnEnable()
    {
        maxHealth = healthDragon;
        currentHealth = maxHealth;
        base.OnEnable();
        dragonAnimator = GetComponent<Animator>();
        speed = runSpeed;
    }

    protected override void Update()
    {
        base.Update();

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer >= maxDistanceRange)
        {
            dragonAnimator.SetBool("isRun",false);
            speed = flySpeed;
        }
        if(distanceToPlayer <= minDistanceRange)
        {
            dragonAnimator.SetBool("isRun",true);
            speed = runSpeed;
        }

        if (distanceToPlayer <= minDistanceRange - 5 )
        {
            dragonAnimator.SetTrigger("Attack");
            speed = 0;
        }
    }

    public override void TakeDame(int amoutOfDame)
    {
        currentHealth -= amoutOfDame;
        if (currentHealth <= 0)
        {
            DestroyGameObject();
            healthDragon += 50;
            SpawnAnimal.amountOfAnimal--;
            EventBroker.CallUpdateScore(point);
            EventBroker.CallUpdateCountAnimal();
        }
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject,3f);
        dragonAnimator.SetTrigger("Sleep");
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Dragon>().enabled = false;

        SpawnAnimal.isSpawnDragon = false;
    }
}
