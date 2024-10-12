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
    private float playerSpeedMouse = 6f;
    private float playerSpeedKey = 3f;
    private float playerSpeedFinal = 6f;
    private float playerAcceleration = 1.05f;
    private Vector2 fixedYMove;
    private Vector2 fixedXMove;
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

        // Get key movements from player
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

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Player Movement to follow mouse
        if (movementOption == false && mousePosition.y >= 4.56 || mousePosition.y <= -4.56)
        {
            if (mousePosition.y >= 4.56)
            {
                fixedYMove = new Vector2(mousePosition.x, 4.56f);
            }
            else
            {
                fixedYMove = new Vector2(mousePosition.x, -4.56f);
            }
            
            transform.position = Vector2.MoveTowards(transform.position, 
                fixedYMove, Time.deltaTime * playerSpeedMouse);
        }
        else if (movementOption == false && (mousePosition.x >= 8.65 || mousePosition.x <= -8.65))
        {
            if (mousePosition.x >= 8.65)
            {
                fixedXMove = new Vector2(8.65f, mousePosition.y);
            }
            else
            {
                fixedXMove = new Vector2(-8.65f,mousePosition.y);
            }

            transform.position = Vector2.MoveTowards(transform.position, 
                fixedXMove, Time.deltaTime * playerSpeedMouse);
        }
        else if (movementOption == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                mousePosition, Time.deltaTime * playerSpeedMouse);
        }

        //Player Movement using keys
        if (movementOption == true)
        {
            // Ship movement if both right and left keys are pressed, or if the x position is within a certain limit
            if ((rightMove && leftMove) || (transform.position.x > 8.52 && !leftMove) 
                || (transform.position.x < -8.52 && !rightMove))
            {
                horizontalMovement = 0;
            }
            else
            {
                horizontalMovement = Input.GetAxisRaw("Horizontal");
            }

            // Ship movement if both up and down keys are pressed or if the y position is within a certain limit
            if ((upMove && downMove) || (transform.position.y > 4.4 && !downMove) 
                || (transform.position.y < -4.4 && !upMove))
            {
                verticalMovement = 0;
            }
            else
            {
                verticalMovement = -Input.GetAxisRaw("Vertical");
            }

            //Implement Movement
            if (playerSpeedKey < playerSpeedFinal && 
                (rightMove || leftMove || upMove || downMove))
            {
                playerSpeedKey *= playerAcceleration;
            }
            else if (playerSpeedKey >= playerSpeedFinal && 
                (rightMove || leftMove || upMove || downMove))
            {
                playerSpeedKey = playerSpeedFinal;
            }
            else if (playerSpeedKey > 1 && 
                (rightMove == false && leftMove == false && upMove == false && downMove == false))
            {
                playerSpeedKey /= playerAcceleration;
            }
            Vector2 Direction = new Vector2(verticalMovement, horizontalMovement) * Time.deltaTime * playerSpeedKey;
            transform.Translate(Direction);
        }
    }
}
