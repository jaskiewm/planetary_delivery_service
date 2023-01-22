using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;
    private float playerSpeed = 1f;
    private float playerSpeedFinal = 5f;
    private float playerAcceleration = 1.1f;
    bool rightMove;
    bool leftMove;
    bool upMove;
    bool downMove;
    /*public GameObject healthBar;
    public GameObject overheatBar;
    public GameObject scoreText;*/

    // Update is called once per frame
    void Update()
    {
        rightMove = Input.GetKey(KeyCode.RightArrow);
        leftMove = Input.GetKey(KeyCode.LeftArrow);
        upMove = Input.GetKey(KeyCode.UpArrow);
        downMove = Input.GetKey(KeyCode.DownArrow);

        Rigidbody m_Rigidbody;
        m_Rigidbody = GetComponent<Rigidbody>();
        //GetComponent<Rigidbody>().angularVelocity = Vector2.zero;
        //GetComponent<Rigidbody>().velocity = Vector2.zero;

        // Ship movement if both right and left keys are pressed, or if the x position is within a certain limit
        if (rightMove && leftMove)
        {
            horizontalMovement = 0;
        }
        else if (transform.position.x > 8.52 && !leftMove)
        {
            horizontalMovement = 0;
        }
        else if (transform.position.x < -8.52 && !rightMove)
        {
            horizontalMovement = 0;
        }
        else
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
        }

        // Ship movement if both up and down keys are pressed or if the y position is within a certain limit
        if (upMove && downMove)
        {
            verticalMovement = 0;
        }
        else if (transform.position.y > 4.4 && !downMove)
        {
            verticalMovement = 0;
        }
        else if (transform.position.y < -4.4 && !upMove)
        {
            verticalMovement = 0;
        }
        else
        {
            verticalMovement = -Input.GetAxisRaw("Vertical");
        }

        //Implement Movement
        if (playerSpeed < playerSpeedFinal && (rightMove || leftMove || upMove || downMove)) {
            playerSpeed *= playerAcceleration;
            //Debug.Log(1);
        }
        else if (playerSpeed >= playerSpeedFinal && (rightMove || leftMove || upMove || downMove))
        {
            playerSpeed = playerSpeedFinal;
            //Debug.Log(2);
        }
        else if (playerSpeed > 1 && (rightMove==false && leftMove==false && upMove == false && downMove == false))
        {
            playerSpeed /= playerAcceleration;
            //Debug.Log(3);
        }
        Vector2 Direction = new Vector2(verticalMovement, horizontalMovement) * Time.deltaTime * playerSpeed;
        transform.Translate(Direction);
        //Debug.Log(playerSpeed);
    }
}
