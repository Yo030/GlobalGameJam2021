using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : MonoBehaviour
{
    public static VariableManager instance = null;
    public TresureToSpawn[] Tresures;
    [Range(1,6)] public int InventorySlots = 3;
    public int Money = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

}
