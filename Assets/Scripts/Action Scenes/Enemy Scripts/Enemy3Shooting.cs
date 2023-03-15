using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy3Shooting : MonoBehaviour
{
    public Rigidbody2D enemyProjectile;
    public Transform enemyShipFrontEnd;
    private float shootingTime = 0f;
    private float enemyBulletSpeed = 500f;
    float enemyShootTime;

    void Update()
    {
        shootingTime += Time.deltaTime;
        enemyShootTime = Random.Range(2f, 5f);

        //Enemy shoots once X time passes (random)
        if (shootingTime >= enemyShootTime && enemyShipFrontEnd.transform.position.x < 8)
        {
            Rigidbody2D projectileInstance;
            projectileInstance = Instantiate(enemyProjectile, enemyShipFrontEnd.position, enemyShipFrontEnd.rotation);
            projectileInstance.AddForce(-transform.right * enemyBulletSpeed);
            shootingTime = 0f;
        }
    }
}
