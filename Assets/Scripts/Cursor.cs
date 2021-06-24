using System;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Texture2D cursor;
    private void Awake()
    {
        ChangeCursor(cursor);
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        UnityEngine.Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }
}
