using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{

    private float enemyHorMovement;
    private float enemyVerMovement;
    private float enemySpeed = 1f;
    private float enemyTopSpeed = 6f;
    private float movementCooldownY = 0f;
    private float PlayerYPosition;
    private float enemyAcceleration;
    private float enemyAccelerationTime = 0.5f;
    private float PlayerYPositionRNG;
    private float enemyXPosition;
    public GameObject enemyShip;

    // Update is called once per frame
    void Update()
    {
        PlayerYPosition = GameObject.Find("Fighter").transform.position.y;
        PlayerYPositionRNG = (PlayerYPosition * 0.1f);
        //X movement for enemies
        if(transform.position.x > 2)
        {
            enemyHorMovement = Random.Range(-0.1f, -0.2f);
            //enemySpeed = 1f;
        }
        else if (transform.position.x < Random.Range(2f, 1f)) //Enemy doesnt move past mid-pooint of map
        {
            enemyHorMovement = 0;
        }

        //Y movement for enemies
        if (movementCooldownY > 0 || movementCooldownY < 2)
        {
            movementCooldownY -= Time.deltaTime;
            enemyVerMovement = Random.Range(PlayerYPosition - PlayerYPositionRNG, PlayerYPosition + PlayerYPositionRNG);
        }
        /*if (transform.position.y < 4.4 && transform.position.y > -4.4 && movementCooldownY <= 0)
        {
            enemyVerMovement = Random.Range(-1f, 1f);
            movementCooldownY = 2f;
        }
        else if (transform.position.y > 4.4)
        {
            enemyVerMovement = Random.Range(-0.1f, -1f);
            movementCooldownY = 2f;
        }
        else if (transform.position.y < -4.4)
        {
            enemyVerMovement = Random.Range(0.1f, 1f);
            movementCooldownY = 2f;
        }*/

        if (enemySpeed >= enemyTopSpeed)
        {
            enemySpeed = enemyTopSpeed;
        }
        else
        {
            enemyAcceleration = enemyTopSpeed/enemyAccelerationTime;
            enemySpeed += (enemyAcceleration * Time.deltaTime * 0.1f);
        }

        enemyXPosition = transform.position.x + enemyHorMovement;
        Vector2 moveNext = new Vector2(enemyXPosition, enemyVerMovement);
        transform.position = Vector2.MoveTowards(transform.position, moveNext, Time.deltaTime * enemySpeed);



        //Vector2 Direction = new Vector2(enemyVerMovement, enemyHorMovement) * Time.deltaTime * enemySpeed;
        //transform.Translate(Direction);

    }
}
