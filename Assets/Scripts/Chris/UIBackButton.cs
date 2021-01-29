using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIBackButton : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(delegate {
            SingletonManager.Singleton.screenManager.LoadLastScreen();
        });
    }
}

