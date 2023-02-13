using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursor_normal;
    public Vector2 normalCursorHotspot;

    public Texture2D cursor_OnButton;
    public Vector2 onButtonCursorHotspot;

    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursor_OnButton, onButtonCursorHotspot, CursorMode.Auto);
    }
    public void OnButtonCursorExit()
    {
        Cursor.SetCursor(cursor_normal, normalCursorHotspot, CursorMode.Auto);
    }
    public void OnButtonCursorClick()
    {
        Cursor.SetCursor(cursor_normal, normalCursorHotspot, CursorMode.Auto);
    }
}
