using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIScreenButton : MonoBehaviour
{
    public Pantallas next_screen;
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate {
            SingletonManager.Singleton.screenManager.ChangeScreen(next_screen);
        });
    }
}
