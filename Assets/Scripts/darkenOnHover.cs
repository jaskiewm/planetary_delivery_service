using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class darkenOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text theText;
    Color baseColor = new Color32(207, 207, 207, 255);
    Color hoverColor = new Color32(142, 142, 142, 255);

    // Start is called before the first frame update 
    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = hoverColor;
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = baseColor;
    }
}
