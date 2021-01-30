using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public string ObjectToSpawn;
    
    private WeightedProbability WeightedProbability_Script;

    private void Start()
    {
        WeightedProbability_Script = FindObjectOfType<WeightedProbability>();
        ObjectToSpawn = WeightedProbability_Script.ChooseObjectInTable(this.name);
    }
}
