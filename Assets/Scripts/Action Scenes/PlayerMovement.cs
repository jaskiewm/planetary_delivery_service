using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Pool;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private bool movementOption;
    private float horizontalMovement;
    private float verticalMovement;    
    private float playerSpeedMouse = 4f;
    private float playerSpeedKey = 3f;
    private float playerSpeedFinal = 8f;
    private float playerAcceleration = 1.1f;
    bool rightMove;
    bool leftMove;
    bool upMove;
    bool downMove;
    public GameObject healthBar;
    public GameObject overheatBar;
    public GameObject scoreText;
    public GameObject invinceBar;

    // Update is called once per frame
    void Update()
    {
        movementOption = options.movementOption;

        rightMove = Input.GetKey(KeyCode.RightArrow);
        leftMove = Input.GetKey(KeyCode.LeftArrow);
        upMove = Input.GetKey(KeyCode.UpArrow);
        downMove = Input.GetKey(KeyCode.DownArrow);

        Rigidbody m_Rigidbody;
        m_Rigidbody = GetComponent<Rigidbody>();
        //GetComponent<Rigidbody>().angularVelocity = Vector2.zero;
        //GetComponent<Rigidbody>().velocity = Vector2.zero;

        //Change transparency of health and overheat when player gets in area
        if (transform.position.x < -4.45 && transform.position.y < -3.32)
        {
            healthBar.GetComponent<CanvasGroup>().alpha = 0.25f;
            overheatBar.GetComponent<CanvasGroup>().alpha = 0.25f;
            invinceBar.GetComponent<CanvasGroup>().alpha = 0.25f;
        }
        else if (transform.position.x > -4.45 || transform.position.y > -3.32)
        {
            healthBar.GetComponent<CanvasGroup>().alpha = 1f;
            overheatBar.GetComponent<CanvasGroup>().alpha = 1f;
            invinceBar.GetComponent<CanvasGroup>().alpha = 1f;
        }

        //Change transparency of score when player gets in area
        if (transform.position.x < -4.45 && transform.position.y > 3.35)
        {
            scoreText.GetComponent<CanvasGroup>().alpha = 0.25f;
        }
        else if (transform.position.x > -4.45 || transform.position.y < 3.35)
        {
            scoreText.GetComponent<CanvasGroup>().alpha = 1f;
        }

        if (movementOption == false) {
        //Player Movement to follow mouse
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, Time.deltaTime * playerSpeedMouse);
        }

        //Player Movement using keys
        if (movementOption == true)
        {
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
            if (playerSpeedKey < playerSpeedFinal && (rightMove || leftMove || upMove || downMove))
            {
                playerSpeedKey *= playerAcceleration;
            }
            else if (playerSpeedKey >= playerSpeedFinal && (rightMove || leftMove || upMove || downMove))
            {
                playerSpeedKey = playerSpeedFinal;
            }
            else if (playerSpeedKey > 1 && (rightMove == false && leftMove == false && upMove == false && downMove == false))
            {
                playerSpeedKey /= playerAcceleration;
            }
            Vector2 Direction = new Vector2(verticalMovement, horizontalMovement) * Time.deltaTime * playerSpeedKey;
            transform.Translate(Direction);
        }
    }
}
