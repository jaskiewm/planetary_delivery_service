using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2Shooting : MonoBehaviour
{
    public Rigidbody2D enemyProjectile;
    public Transform enemyShipFrontEnd;
    private float shootingTime = 0f;
    private float enemyBulletSpeed = 300f;
    float playerYPosition;
    float enemyYPosition;
    float enemyYShooting;

    void Update()
    {
        shootingTime += Time.deltaTime;
        playerYPosition = GameObject.Find("Fighter").transform.position.y;
        enemyYPosition = enemyShipFrontEnd.position.y;
        enemyYShooting = playerYPosition - enemyYPosition;


        //Shooting time hits 5 sec cooldown
        if (shootingTime >= 2f && enemyShipFrontEnd.transform.position.x < 8 && enemyYShooting <= 0.1f && enemyYShooting >= -0.1f)
        {
            Rigidbody2D projectileInstance;
            projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
            projectileInstance.AddForce(-transform.right * enemyBulletSpeed);
            shootingTime = 0f;
        }
    }
}
