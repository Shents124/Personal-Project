using UnityEngine;

public class Dragon : Animal,IDamageable
{
    private float maxDistanceRange = 20f;
    private float minDistanceRange = 15f;
    private float rangeAttack = 5f;
    private float runSpeed = 18f;
    private float flySpeed = 22f;
    
    private Animator dragonAnimator;
    public ParticleSystem dirt;
    
    protected override void OnEnable()
    {
        maxHealth = healthDragon;
        currentHealth = maxHealth;
        dragonAnimator = GetComponent<Animator>();
        speed = runSpeed;
        dame = 15;
        base.OnEnable();
    }

    protected override void Update()
    {
        this.transform.LookAt(playerTransform);
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
            dirt.Play();
        }

        if (distanceToPlayer <= rangeAttack )
        {
            dragonAnimator.SetTrigger("Attack");
            speed = 0;
        }
    }

    public void TakeDame(int amoutOfDame)
    {
        currentHealth -= amoutOfDame;
        if (currentHealth <= 0)
        {
            DestroyGameObject();
            healthDragon += 50;
            EventBroker.CallUpdateScore(pointScore);
            SoundManager.Instance.PlaySound(SoundManager.Instance.bossDead);
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
