using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class EndGame: MonoBehaviour
{
    public GameObject EndMenuUI;

    private void Start()
    {
        EndMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the player game object
        GameObject playerObject = GameObject.FindWithTag("Player");
        PlayerHealth playerhealth = (PlayerHealth)playerObject.GetComponent(typeof(PlayerHealth));
        
        // Activate end menu when player loses all health
        if (playerhealth.getHealth() <= 0)
        {
            Time.timeScale = 0f;
            EndMenuUI.SetActive(true);
        }  
    }

    // Click to play again
    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("MainGame");
    }

    // Click to quit
    public void OnClickQuit()
    {
        Time.timeScale = 1f;
        EndMenuUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
