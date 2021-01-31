using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public string ObjectToSpawn;
    public int ObjectID;
    
    [SerializeField] private WeightedProbability WeightedProbability_Script;

    private void Start()
    {
        int _objecttospawn = WeightedProbability_Script.ChooseObjectInTable();

        ObjectToSpawn = WeightedProbability_Script.Tresures[_objecttospawn].Name;
        ObjectID = WeightedProbability_Script.Tresures[_objecttospawn].id;
    }
}
