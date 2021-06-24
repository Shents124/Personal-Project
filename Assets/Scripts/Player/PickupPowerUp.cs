using System;
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

    private void Start()
    {
        timeUsingShield = timeCountDownPowerUp;
        timeShootingDoubleBullet = timeCountDownPowerUp;
        timeShootingTripleBullet = timeCountDownPowerUp;
    }

    private void FixedUpdate()
    {
        if(powerUpType == PowerUpType.HealthUp)
            HealthUp();
        if(powerUpType == PowerUpType.Shield)
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
            Debug.Log("Has " + powerUpType);
            Destroy(other.gameObject);
        }
    }

    private void HealthUp()
    {
        GetComponent<PlayerLife>().currentHealth += healthUpPoint;
        powerUpType = PowerUpType.None;
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
            powerUpType = PowerUpType.None;
        }
    }

    private void ShootingDoubleBullet()
    {
        Shooting playerShooting = GetComponent<Shooting>();
        playerShooting.isShootingDouble = true;
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
        timeShootingTripleBullet -= Time.deltaTime;
        if (timeShootingTripleBullet <= 0)
        {
            timeShootingTripleBullet = timeCountDownPowerUp;
            playerShooting.isShootingTriple = false;
            powerUpType = PowerUpType.None;
        }
    }
}