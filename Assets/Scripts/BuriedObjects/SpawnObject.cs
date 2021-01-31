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
        Debug.Log(_objecttospawn);
        ObjectToSpawn = VariableManager.instance.Tresures[_objecttospawn].Name;
        ObjectID = VariableManager.instance.Tresures[_objecttospawn].id;
    }
}
