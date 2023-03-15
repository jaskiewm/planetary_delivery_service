using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2Shooting : MonoBehaviour
{
    public Rigidbody2D enemyProjectile;
    public Transform enemyShipFrontEnd;
    private float shootingTime = 0f;
    private float enemyBulletSpeed = 800f;
    float playerYPosition;
    float enemyYPosition;
    float enemyYShooting;

    void Update()
    {
        shootingTime += Time.deltaTime;
        playerYPosition = GameObject.Find("Fighter").transform.position.y;
        enemyYPosition = enemyShipFrontEnd.position.y;
        enemyYShooting = playerYPosition - enemyYPosition;


        //Shooting time hits 5 sec cooldown and ship passes infront of ship
        if (shootingTime >= 2f && enemyShipFrontEnd.transform.position.x < 8 && enemyYShooting <= 0.1f && enemyYShooting >= -0.1f)
        {
            StartCoroutine(CreateProjectileWithDelay());
            shootingTime = 0f;
        }
    }
    IEnumerator CreateProjectileWithDelay()
    {
        Rigidbody2D projectileInstance;
        projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
        projectileInstance.AddForce(-transform.right * enemyBulletSpeed);
        yield return new WaitForSeconds(0.5f);
        projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
        projectileInstance.AddForce(-transform.right * enemyBulletSpeed);
        yield return null;
    }

    }
