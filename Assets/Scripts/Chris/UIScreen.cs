using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class UIScreen : MonoBehaviour
{
    public Screen screen;
    [SerializeField] UnityEvent OnActiveScreen;

    private void Start()
    {
        //Subscribe the event for active and deactive screen
        SingletonManager.Singleton.screenManager.OnScreenChange += ActiveScreen;
        SingletonManager.Singleton.screenManager.RegisterScreen();
    }

    //If the current scene is this one, activate it
    private void ActiveScreen(Screen current_screen)
    {
        if(current_screen == screen)
        {
            this.GetComponent<RectTransform>().localPosition = Vector3.zero;
            this.gameObject.SetActive(true);
            OnActiveScreen.Invoke();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }


    private void OnDestroy()
    {
        //if destroyed just remove the suscribed event
        SingletonManager.Singleton.screenManager.OnScreenChange -= ActiveScreen;
    }
}
