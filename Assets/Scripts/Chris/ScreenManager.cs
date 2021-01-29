using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class ScreenManager : MonoBehaviour
{
    Screen current_screen = 0;
    [SerializeField] Screen start_screen;
    [SerializeField] List<Screen> screen_history = new List<Screen>();

    public event Action<Screen> OnScreenChange;
    [SerializeField] UnityEvent OnCompleteScreenChange;


    private void Awake()
    {
        //Register event for swapping screens
        OnScreenChange += _ChangeScreen;
        OnScreenChange?.Invoke(start_screen);
    }

    private void Start()
    {
        //Load start_screen
        OnScreenChange?.Invoke(start_screen);
    }

    //Event loaded OnScreenChange
    private void _ChangeScreen(Screen selected_screen)
    {
        if (current_screen == selected_screen)
            return;
        current_screen = selected_screen;
        screen_history.Add(current_screen);
        OnCompleteScreenChange.Invoke();
    }

    //Change screen to the desired one
    public void ChangeScreen(Screen selected_screen)
    {
        OnScreenChange?.Invoke(selected_screen);
    }


    //Load the screen that was before the current one
    public void LoadLastScreen()
    {
        if(screen_history.Count > 1)
        {
            screen_history.RemoveAt(screen_history.Count - 1);
            ChangeScreen(screen_history[screen_history.Count - 1]);
            screen_history.RemoveAt(screen_history.Count - 1);
        }
    }

    public void RegisterScreen()
    {
        OnScreenChange?.Invoke(current_screen);
    }
}

[Serializable]
public enum Screen
{
    SPLASH_SCREEN,
    MAIN_MENU,
    ABOUT_US,
    OPTIONS,
    GAME_HUD,
}