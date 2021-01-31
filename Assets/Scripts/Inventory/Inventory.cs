using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private WeightedProbability WeightedProbability_Script;
    [SerializeField] private Image[] InventorySlots;
    [SerializeField] private string[] InventoryList;
    //[SerializeField] private SetImageInSlot SetImageInSlot_Script;
    //public TresureToSpawn[] VariableManager.instance.Tresures;

    public Image BackgroundImageComponent;
    public Image ParentImageComponent;

    [SerializeField] private SetImageInSlot[] ChildImages;

    public SetImageInSlot SetImageInSlot_Script;
    private Color CompleteTranspaernt = new Color(0,0,0,0);
    private Color NormalSlotColor = new Color(0, 0, 0, .3139f);

    private void Start()
    {
        ChildImages = new SetImageInSlot[VariableManager.instance.InventorySlots];

        for (int i = 0; i < VariableManager.instance.InventorySlots; i++)
        {
            ChildImages[i] = InventorySlots[i].transform.gameObject.GetComponentInChildren<SetImageInSlot>();
        }

        for (int i=0; i<VariableManager.instance.InventorySlots; i++)
        {
            BackgroundImageComponent = InventorySlots[i].GetComponent<Image>();
            BackgroundImageComponent.color = NormalSlotColor;
        }
    }

    public void CheckForSpaces(GameObject _newitem, int _maxhelditems)
    {
        //Debug.Log("Mi lista: " + this.InventoryList.Length);
        //Debug.Log("Num Max de inventario: " + _maxhelditems);

        for (int i=0; i < _maxhelditems; i++)
        {
            //Debug.Log("Mi lista: " + this.InventoryList[i]);
            if (this.InventoryList[i] == "")
            {
                //Debug.Log("Hay espacio");
                SetInArray(_newitem, i);
                return;
            }
        }
        //Debug.Log("No espacio");
    }
    
    private void SetInArray(GameObject _newitem, int _arrarynum)
    {
        SpawnObject _spawnobjectscrip = _newitem.GetComponent<SpawnObject>();
        ChildImages[_arrarynum].SetImage(VariableManager.instance.Tresures[_spawnobjectscrip.ObjectID].UISprite);

        this.InventoryList[_arrarynum] = VariableManager.instance.Tresures[_spawnobjectscrip.ObjectID].Name;
    }
}
