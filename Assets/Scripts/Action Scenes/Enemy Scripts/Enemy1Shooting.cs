using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1Shooting : MonoBehaviour
{
    public Rigidbody2D enemyProjectile;
    public Transform enemyShipFrontEnd;
    private float shootingTime = 0f;
    private float enemyBulletSpeed = 300f;
    float playerYPosition;
    float enemyYPosition;

    void Update()
    {
        shootingTime += Time.deltaTime;
        playerYPosition = GameObject.Find("Fighter").transform.position.y;
        enemyYPosition = enemyShipFrontEnd.position.y;

        //Shooting time hits 5 sec cooldown
        if (shootingTime >= 2f && enemyShipFrontEnd.transform.position.x < 8 )
        {
            Rigidbody2D projectileInstance;
            projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
            projectileInstance.AddForce(-transform.right* enemyBulletSpeed);
            shootingTime = 0f;
        }
    }
}
