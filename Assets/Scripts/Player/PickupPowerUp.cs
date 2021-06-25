using UnityEngine;

public class PickupPowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    private string powerUp = "PowerUp";
    private int healthUpPoint = 50;
    private float timeCountDownPowerUp = 10f;
    private float timeUsingShield;
    private float timeShootingDoubleBullet;
    private float timeShootingTripleBullet;

    private bool isHasShield = false;
    public ParticleSystem shieldEffect;

    private void Start()
    {
        timeUsingShield = timeCountDownPowerUp;
        timeShootingDoubleBullet = timeCountDownPowerUp;
        timeShootingTripleBullet = timeCountDownPowerUp;
    }

    private void Update()
    {
        if (isHasShield)
        {
            ProtectPlayer();
        }

        if(powerUpType == PowerUpType.DoubleBullet)
            ShootingDoubleBullet();
        if(powerUpType == PowerUpType.TripleBullet)
            ShootingTripleBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(powerUp))
        {
            powerUpType = other.GetComponent<PowerUp>().powerUpType;
            DestroyGameObject(other.gameObject);
        }

        if (other.CompareTag("HealthUp"))
        {
            DestroyGameObject(other.gameObject);
            HealthUp();
        }

        if (other.CompareTag("Protection"))
        {
            DestroyGameObject(other.gameObject);
            isHasShield = true;
            shieldEffect.Play();
        }
        SoundManager.Instance.PlaySound(SoundManager.Instance.collectingItem);
    }

    private void HealthUp()
    {
        PlayerLife playerLife = GetComponent<PlayerLife>();
        playerLife.currentHealth += healthUpPoint;
        playerLife.healthBar.SetHealth(playerLife.currentHealth);
    }

    private void ProtectPlayer()
    {
        PlayerLife playerLife = GetComponent<PlayerLife>();
        playerLife.isHasShield = true;
        timeUsingShield -= Time.deltaTime;
        
        if (timeUsingShield <= 0)
        {
            timeUsingShield = timeCountDownPowerUp;
            playerLife.isHasShield = false;
            isHasShield = false;
            shieldEffect.Stop();
        }
    }

    private void ShootingDoubleBullet()
    {
        Shooting playerShooting = GetComponent<Shooting>();
        playerShooting.isShootingDouble = true;
        playerShooting.isShootingTriple = false;
        timeShootingDoubleBullet -= Time.deltaTime;
        
        if (timeShootingDoubleBullet <= 0)
        {
            timeShootingDoubleBullet = timeCountDownPowerUp;
            playerShooting.isShootingDouble = false;
            powerUpType = PowerUpType.None;
        }
    }

    private void ShootingTripleBullet()
    {
        Shooting playerShooting = GetComponent<Shooting>();
        playerShooting.isShootingTriple = true;
        playerShooting.isShootingDouble = false;
        timeShootingTripleBullet -= Time.deltaTime;
        
        if (timeShootingTripleBullet <= 0)
        {
            timeShootingTripleBullet = timeCountDownPowerUp;
            playerShooting.isShootingTriple = false;
            powerUpType = PowerUpType.None;
        }
    }

    private void DestroyGameObject(GameObject other)
    {
        Destroy(other);
        SpawnPowerUp.amountOfPowerUp--;
    }
}