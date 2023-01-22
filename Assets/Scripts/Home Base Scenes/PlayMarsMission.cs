using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMarsMission : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayMars()
    {
        SceneManager.LoadScene("MainGame");
        PauseMenu.isGamePaused = false;
    }
}
