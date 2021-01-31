using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : MonoBehaviour
{
    public static VariableManager instance = null;
    public TresureToSpawn[] Tresures;

    [Space]
    public string[] InventoryList;
    [Range(1,6)] public int MaxInventorySlots = 3;

    [Space]
    public int Money = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }
}
