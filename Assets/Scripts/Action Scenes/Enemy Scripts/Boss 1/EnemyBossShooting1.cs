using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBossShooting1 : MonoBehaviour
{
    public Rigidbody2D enemyProjectile;
    private float[] bulletDirection = { -0.5f, -0.25f, 0f, 0.25f, 0.5f};
    private Vector2 bulletDirectionVector;
    public Transform enemyShipFrontEnd;
    private float shootingTime = 0f;
    private float enemyBulletSpeed = 500f;
    float enemyShootTime;
    private EnemyBossHealth enemyBossHealth;

    private void Start()
    {
        enemyShootTime = UnityEngine.Random.Range(2f, 4f);
        enemyBossHealth = GetComponent<EnemyBossHealth>();
    }

    void Update()
    {
        int health = enemyBossHealth.health;
        int healthMax = enemyBossHealth.healthMax;

        shootingTime += Time.deltaTime;

        //Enemy shoots once X time passes (random)
        if (shootingTime >= enemyShootTime && enemyShipFrontEnd.transform.position.x < 8 && (health >= (healthMax / 2)))
        {
            StartCoroutine(shootingTypesFullHealth());
            shootingTime = 0f;
        }
        else if (shootingTime >= enemyShootTime && enemyShipFrontEnd.transform.position.x < 8 && (health < (healthMax/2)))
        {
            StartCoroutine(shootingTypesHalfHealth());
            shootingTime = 0f;
        }

    }
    IEnumerator shootingTypesFullHealth()
    {
        int randomNum = UnityEngine.Random.Range(1, 4);
        Debug.Log(randomNum);
        Rigidbody2D projectileInstance;

        switch (randomNum)
        {
            case 1:
                for (int i = 0; i < bulletDirection.Length; i++)
                {
                    bulletDirectionVector = new Vector2(-1f, bulletDirection[i]).normalized; ;
                    projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
                    projectileInstance.AddForce(bulletDirectionVector * enemyBulletSpeed);
                    yield return new WaitForSeconds(0.2f);
                }
                break;
            case 2:
                for (int i = bulletDirection.Length-1; i >= 0; i--)
                {
                    bulletDirectionVector = new Vector2(-1f, bulletDirection[i]).normalized; ;
                    projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
                    projectileInstance.AddForce(bulletDirectionVector * enemyBulletSpeed);
                    yield return new WaitForSeconds(0.2f);
                }
                break;
            case 3:
                for (int i = 0; i < bulletDirection.Length; i++)
                {
                    bulletDirectionVector = new Vector2(-1f, bulletDirection[i]).normalized; ;
                    projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
                    projectileInstance.AddForce(bulletDirectionVector * enemyBulletSpeed);
                }
                break;
        }
        yield return null;
    }
    IEnumerator shootingTypesHalfHealth()
    {
        int randomNum = UnityEngine.Random.Range(1, 4);
        Debug.Log(randomNum);
        Rigidbody2D projectileInstance;

        switch (randomNum)
        {
            case 1:
                for (int j = 0; j <3; j++) {
                    for (int i = 0; i < bulletDirection.Length; i++)
                    {
                        bulletDirectionVector = new Vector2(-1f, bulletDirection[i]).normalized; ;
                        projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
                        projectileInstance.AddForce(bulletDirectionVector * enemyBulletSpeed);
                        yield return new WaitForSeconds(0.15f);
                    }
                }
                break;
            case 2:
                for (int j = 0; j < 3; j++)
                {
                    for (int i = bulletDirection.Length - 1; i >= 0; i--)
                    {
                        bulletDirectionVector = new Vector2(-1f, bulletDirection[i]).normalized; ;
                        projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
                        projectileInstance.AddForce(bulletDirectionVector * enemyBulletSpeed);
                        yield return new WaitForSeconds(0.15f);
                    }
                }
                break;
            case 3:
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < bulletDirection.Length; i++)
                    {
                        bulletDirectionVector = new Vector2(-1f, bulletDirection[i]).normalized; ;
                        projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
                        projectileInstance.AddForce(bulletDirectionVector * enemyBulletSpeed);
                    }
                    yield return new WaitForSeconds(0.2f);
                }
                break;
        }
        yield return null;

    }
}
