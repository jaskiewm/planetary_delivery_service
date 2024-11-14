using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options: MonoBehaviour
{
    public static bool movementOption = false; //false = mouse , true = keybindings

    public void MovementOptions()
    {
        if(movementOption == false)
            movementOption = true; // Movement = keybind
        else if (movementOption == true)
            movementOption = false; // Movement = mouse
    }

    public bool GetMovement()
    {
        return movementOption;
    }
}
