using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    [HideInInspector]
    public static SingletonManager Singleton;
    public ScreenManager screenManager;

    void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void JustForTestingEvents()
    {
        Debug.Log("Triggered");
    }
}
