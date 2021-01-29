using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISplasScreen : UIScreen
{
    public float timeToSkip = 3.0f;
    public Pantallas nextScreen = 0;
    private float timer = 0;

    private void FixedUpdate()
    {
        if(timer > timeToSkip)
        {
            SingletonManager.Singleton.screenManager.ChangeScreen(nextScreen);
        }
        timer += Time.fixedDeltaTime;
    }
}
