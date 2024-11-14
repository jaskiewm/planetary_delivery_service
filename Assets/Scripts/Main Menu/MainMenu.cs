using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("MainGame");
        PauseMenu.isGamePaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}