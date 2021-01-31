using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private WeightedProbability WeightedProbability_Script;
    [SerializeField] private Image[] InventorySlots;
    //[SerializeField] private string[] InventoryList;

    public Image BackgroundImageComponent;
    public Image ParentImageComponent;

    [SerializeField] private SetImageInSlot[] ChildImages;

    public SetImageInSlot SetImageInSlot_Script;
    private Color CompleteTranspaernt = new Color(0,0,0,0);
    private Color NormalSlotColor = new Color(0, 0, 0, .3139f);

    private void Start()
    {
        ReloadSlots(0);
    }

    public void CheckForSpaces(GameObject _newitem)
    {
        //Debug.Log("Mi lista: " + this.InventoryList.Length);
        //Debug.Log("Num Max de inventario: " + _maxhelditems);

        for (int i=0; i < VariableManager.instance.MaxInventorySlots; i++)
        {
            //Debug.Log("Mi lista: " + this.VariableManager.instance.InventoryList[i]);
            if (VariableManager.instance.InventoryList[i] == "")
            {
                //Debug.Log("Hay espacio");
                SetInArray(_newitem, i);
                return;
            }
        }
        Debug.Log("NO SPACE");
    }
    
    private void SetInArray(GameObject _newitem, int _arrarynum)
    {
        SpawnObject _spawnobjectscrip = _newitem.GetComponent<SpawnObject>();
        ChildImages[_arrarynum].SetImage(VariableManager.instance.Tresures[_spawnobjectscrip.ObjectID].UISprite);

        VariableManager.instance.InventoryList[_arrarynum] = VariableManager.instance.Tresures[_spawnobjectscrip.ObjectID].Name;
    }

    public void ReloadSlots(int _add)
    {
        if(VariableManager.instance.MaxInventorySlots < 5) VariableManager.instance.MaxInventorySlots += _add;

        ChildImages = new SetImageInSlot[VariableManager.instance.MaxInventorySlots];

        for (int i = 0; i < VariableManager.instance.MaxInventorySlots; i++)
        {
            ChildImages[i] = InventorySlots[i].transform.gameObject.GetComponentInChildren<SetImageInSlot>();
        }

        for (int i = 0; i < VariableManager.instance.MaxInventorySlots; i++)
        {
            BackgroundImageComponent = InventorySlots[i].GetComponent<Image>();
            BackgroundImageComponent.color = NormalSlotColor;
        }
    }
}
