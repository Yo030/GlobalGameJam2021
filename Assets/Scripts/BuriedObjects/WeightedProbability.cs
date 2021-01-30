using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedProbability : MonoBehaviour
{
    [SerializeField] private TresureToSpawn[] Tresures;

    private int TotalPrababilitySum;
    private int RandomObjectToSpawn;
    
    public string ChooseObjectInTable(string _caller)
    {
        TotalPrababilitySum = 0;

        foreach (var item in Tresures)
        {
            TotalPrababilitySum += item.Prabability;
        }

        RandomObjectToSpawn = Random.Range(0, TotalPrababilitySum);
        Debug.Log("Caller: " + _caller + " number is: " + RandomObjectToSpawn);

        for (int i=0; i< Tresures.Length; i++)
        {
            if (RandomObjectToSpawn <= Tresures[i].Prabability)
            {
                //Debug.Log("The chosen is: " + Tresures[i].Name);
                Debug.Log("It is: " + Tresures[i].Name);
                return Tresures[i].Name;
            }
            else
            {
                RandomObjectToSpawn -= Tresures[i].Prabability;
            }
        }
        return Tresures[0].Name;
    }
}
