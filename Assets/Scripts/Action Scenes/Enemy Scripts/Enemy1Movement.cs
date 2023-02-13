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
    private float enemyXPosition;
    private float enemyYPosition;
    private float enemyYPositionDifference;
    float randomNum;
    public GameObject enemyShip;

    // Update is called once per frame
    private void Start()
    {
        randomNum = Random.Range(1f, -2f);
    }

    void Update()
    {
        enemyYPosition = enemyShip.transform.position.y;
        enemyXPosition = enemyShip.transform.position.x;
        PlayerYPosition = GameObject.Find("Fighter").transform.position.y;
        enemyYPositionDifference = PlayerYPosition - enemyYPosition;

        //X movement for enemies
        if (enemyXPosition > Random.Range(5.5f, 7.5f))
        {
            enemyHorMovement = -3f;
            movementCooldownY = 3f;
        }
        else if (enemyXPosition < randomNum) //Enemy doesnt move past mid-point of map
        {
            enemyHorMovement = 0;
        }
        else if (enemyHorMovement != 0)//(enemyXPosition > 2)
        {
            enemyHorMovement = -0.5f;
            movementCooldownY = 0f;
        }
        /*else if (enemyXPosition < Random.Range(2f, -1f)) //Enemy doesnt move past mid-pooint of map
        {
            enemyHorMovement = 0;
        }*/

        //Y movement for enemies
        if (movementCooldownY > 0 /*|| movementCooldownY < 2*/)
        {
            movementCooldownY -= Time.deltaTime;
            //movementCooldownY = 5f;
            //enemyVerMovement = Random.Range(PlayerYPosition - PlayerYPositionRNG, PlayerYPosition + PlayerYPositionRNG);
        }

        if (enemyYPosition < 4.4 && enemyYPosition > -4.4 && movementCooldownY <= 0)
        {
            enemyVerMovement = (enemyYPositionDifference * 0.1f);
            //movementCooldownY = 0.5f;
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

        //enemyXPosition = transform.position.x + enemyHorMovement;
        //Vector2 moveNext = new Vector2(enemyXPosition, enemyVerMovement);
        //transform.position = Vector2.MoveTowards(transform.position, moveNext, Time.deltaTime * enemySpeed);

        Vector2 Direction = new Vector2(enemyHorMovement, enemyVerMovement) * Time.deltaTime * enemySpeed;
        transform.Translate(Direction);
    }
}
