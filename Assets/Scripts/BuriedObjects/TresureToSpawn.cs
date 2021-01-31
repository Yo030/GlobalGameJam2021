using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TresureToSpawn
{
    public string Name;
    public int id;
    public GameObject GameObjectToSpawn;
    public int Prabability;
    [Space]
    public int TriesToDig;
    public int TimesToDig;
}
