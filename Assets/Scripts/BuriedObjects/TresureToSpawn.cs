using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TresureToSpawn
{
    public string Name;
    public int id;
    [Space]
    public int Prabability;
    public int TriesToDig;
    public int TimesToDig;
    [Space]
    public GameObject GameObjectToSpawn;
    public Sprite UISprite;
}
