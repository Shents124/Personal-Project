using UnityEngine;

public class PickupPowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    private string powerUp = "PowerUp";
    private int healthUpPoint = 20;
    private float timeCountDownPowerUp = 10f;
    private float timeUsingShield;
    private float timeShootingDoubleBullet;
    private float timeShootingTripleBullet;

    private bool isHasShield = false;

    private void Start()
    {
        timeUsingShield = timeCountDownPowerUp;
        timeShootingDoubleBullet = timeCountDownPowerUp;
        timeShootingTripleBullet = timeCountDownPowerUp;
    }

    private void FixedUpdate()
    {
        if(isHasShield)
            ProtectPlayer();
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
        }
    }

    private void HealthUp()
    {
        GetComponent<PlayerLife>().currentHealth += healthUpPoint;
    }

    private void ProtectPlayer()
    {
        PlayerLife playerLife = GetComponent<PlayerLife>();
        playerLife.isHasShield = true;
        Debug.Log(playerLife.isHasShield);
        timeUsingShield -= Time.deltaTime;
        if (timeUsingShield <= 0)
        {
            timeUsingShield = timeCountDownPowerUp;
            playerLife.isHasShield = false;
            isHasShield = false;
            Debug.Log(playerLife.isHasShield);
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