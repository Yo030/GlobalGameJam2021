using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideCursor : MonoBehaviour
{
    private void Awake()
    {
        Hide();
    }

    public void Hide()
    {
        Cursor.visible = false;
        Debug.Log("Cursor is locked: " + Cursor.visible);

        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Show()
    {
        Cursor.visible = true;
        Debug.Log("Cursor is locked: " + Cursor.visible);

        Cursor.lockState = CursorLockMode.None;
    }
}
