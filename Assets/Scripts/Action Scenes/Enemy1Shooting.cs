using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1Shooting : MonoBehaviour
{
    public Rigidbody2D enemyProjectile;
    public Transform enemyShipFrontEnd;
    private float shootingTime = 0f;
    private float enemyBulletSpeed = 500f;
    void Update()
    {
        shootingTime += Time.deltaTime;

        //Shooting time hits 5 sec cooldown
        if (shootingTime >= 2f)
        {
            Rigidbody2D projectileInstance;
            projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
            projectileInstance.AddForce(-transform.right* enemyBulletSpeed);
            shootingTime = 0f;
        }
    }
}
