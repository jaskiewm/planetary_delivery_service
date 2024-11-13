using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouseControl : MonoBehaviour
{
    Text moveText;
    private Options movementOption = new Options();

    private void Start()
    {
        moveText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementOption.GetMovement() == false) //false = mouse , true = keybindings
            moveText.text = "Mouse";
        else //false = mouse , true = keybindings
            moveText.text = "Keys";

    }
}
