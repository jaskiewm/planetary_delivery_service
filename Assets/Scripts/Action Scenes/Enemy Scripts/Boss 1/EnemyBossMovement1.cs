using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossMovement : MonoBehaviour
{

    private float enemyHorMovement;
    private float enemyVerMovement;
    private float enemySpeed = 1f;
    private float enemyTopSpeed = 6f;
    private float movementCooldownY = 0f;
    private float movementCooldownX = 0f;
    private float enemyAcceleration;
    private float enemyAccelerationTime = 0.5f;
    private float enemyXPosition;
    private float enemyYPosition;
    bool enemyMoveX = false;

    float randomXPosition;
    public GameObject enemyShip;

    // Update is called once per frame
    private void Start()
    {
        randomXPosition = Random.Range(4f, 5f);
    }

    void Update()
    {
        enemyYPosition = enemyShip.transform.position.y;
        enemyXPosition = enemyShip.transform.position.x;

        //X movement for enemies
        if (enemyXPosition > Random.Range(5.5f, 7.5f) && enemyMoveX == false)
        {
            enemyHorMovement = -3f;
            movementCooldownY = 4f;
        }
        else if (enemyXPosition < randomXPosition && enemyMoveX == false) //Enemy doesnt move past mid-point of map
        {
            enemyHorMovement = 0;
            enemyMoveX = true;
        }
        else if (enemyHorMovement != 0 && enemyMoveX == false) //(enemyXPosition > 2)
        {
            enemyHorMovement = -0.5f;
            movementCooldownY = 0f;
        }


        //if the enemy goes between random X Position and +1, it moves left or right at 0.1f 

        //Y Movement for player 
        if (enemyYPosition < 4.4 && enemyYPosition > -4.4 && movementCooldownY <= 0)
        {
            enemyVerMovement = Random.Range(-0.1f, 0.1f);
            movementCooldownY = 6f;
        }
        else if (enemyYPosition > 2.9)
        {
            //enemyVerMovement = Random.Range(-0.1f, -0.2f);
            //movementCooldownY = 2f;
            enemyVerMovement = -0.1f;
            movementCooldownY = Random.Range(2f, 3f);
            movementCooldownY = 6f;
        }
        else if (enemyYPosition < -2.9)
        {
            //enemyVerMovement = Random.Range(0.1f, 0.2f);
            //movementCooldownY = 2f;
            enemyVerMovement = 0.1f;
            movementCooldownY = Random.Range(2f, 3f);
            movementCooldownY = 6f;
        }
        //Cooldown Timer after Y movement
        if (movementCooldownY > 0)
        {
            movementCooldownY -= Time.deltaTime;
        }
        else
        {
            movementCooldownY = 0;
        }

        if (movementCooldownX > 0)
        {
            movementCooldownY -= Time.deltaTime;
        }
        else
        {
            movementCooldownX = 0;
        }

        //Speed and acceleration of enemy
        if (enemySpeed >= enemyTopSpeed)
        {
            enemySpeed = enemyTopSpeed;
        }
        else
        {
            enemyAcceleration = enemyTopSpeed / enemyAccelerationTime;
            enemySpeed += (enemyAcceleration * Time.deltaTime * 0.1f);
        }

        //enemyHorMovement = transform.position.x + enemyHorMovement;

        Vector2 Direction = new Vector2(enemyHorMovement, enemyVerMovement) * Time.deltaTime * enemySpeed;
        transform.Translate(Direction);

        //Vector2 moveNext = new Vector2(enemyXPosition, enemyVerMovement);
        //transform.position = Vector2.MoveTowards(transform.position, moveNext, Time.deltaTime * enemySpeed);
    }
}
