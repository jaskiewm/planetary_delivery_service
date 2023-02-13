using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options : MonoBehaviour
{
    public static bool movementOption = false; //false = mouse , true = keybindings

    public void movement()
    {
        if(movementOption == false)
        {
            movementOption = true;
            Debug.Log(movementOption);
        }
        else if (movementOption == true)
        {
            movementOption = false;
            Debug.Log(movementOption);
        }
    }
}
