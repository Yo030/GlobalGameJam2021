using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private WeightedProbability WeightedProbability_Script;
    [SerializeField] private Image[] InventorySlots;
    [SerializeField] private string[] InventoryList;
    public TresureToSpawn[] Tresures;

    private Image ImageComponent;
    private Color CompleteTranspaernt = new Color(0,0,0,0);
    private Color NormalSlotColor = new Color(0, 0, 0, .3139f);

    private void Start()
    {
        for(int i=0; i<VariableManager.instance.InventorySlots; i++)
        {
            ImageComponent = InventorySlots[i].GetComponent<Image>();
            ImageComponent.color = NormalSlotColor;
        }
    }

    public void CheckForSpaces(GameObject _newitem, int _maxhelditems)
    {
        Debug.Log("Mi lista: " + this.InventoryList.Length);
        Debug.Log("Num Max de inventario: " + _maxhelditems);

        for (int i=0; i < _maxhelditems; i++)
        {
            Debug.Log("Mi lista: " + this.InventoryList[i]);
            if (this.InventoryList[i] == "")
            {
                Debug.Log("Hay espacio");
                SetInArray(_newitem, i);
                return;
            }
        }
        Debug.Log("No espacio");
    }
    
    private void SetInArray(GameObject _newitem, int _arrarynum)
    {
        SpawnObject _spawnobjectscrip = _newitem.GetComponent<SpawnObject>();
        this.InventoryList[_arrarynum] = WeightedProbability_Script.Tresures[_spawnobjectscrip.ObjectID].Name;
    }
}
