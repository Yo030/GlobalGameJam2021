using UnityEngine;

public class WeightedProbability : MonoBehaviour
{
    //public TresureToSpawn[] VariableManager.instance.Tresures;

    private int TotalPrababilitySum;
    private int RandomObjectToSpawn;


    public int ChooseObjectInTable()
    {
        TotalPrababilitySum = 0;

        foreach (var item in VariableManager.instance.Tresures)
        {
            TotalPrababilitySum += item.Prabability;
        }

        RandomObjectToSpawn = Random.Range(0, TotalPrababilitySum);
        //Debug.Log("Caller: " + _caller + " number is: " + RandomObjectToSpawn);

        for (int i=0; i< VariableManager.instance.Tresures.Length; i++)
        {
            if (RandomObjectToSpawn <= VariableManager.instance.Tresures[i].Prabability)
            {
                //Debug.Log("The chosen is: " + VariableManager.instance.Tresures[i].Name);
                //Debug.Log("It is: " + VariableManager.instance.Tresures[i].Name);
                return VariableManager.instance.Tresures[i].id;
            }
            else
            {
                RandomObjectToSpawn -= VariableManager.instance.Tresures[i].Prabability;
            }
        }
        return VariableManager.instance.Tresures[0].id;
    }
}
