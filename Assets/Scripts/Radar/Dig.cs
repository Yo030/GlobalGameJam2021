using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dig : MonoBehaviour
{
    [SerializeField] private GameObject UI_ToActivate;
    [SerializeField] private ShowHideCursor ShowHideCursor_Script;
    [SerializeField] private DigMeter DigMeter_Script;
    [SerializeField] private WeightedProbability WeightedProbability_Script;

    /*
    public void ShowDigUI(bool _show)
    {
        DigUI.SetActive(_show);//Show UI
    }*/

    public void DiscoverTresure(GameObject _buriedobject)
    {
        int _id = _buriedobject.GetComponent<SpawnObject>().ObjectID;

        Debug.Log("YOU JUST FOUND A: "+ VariableManager.instance.Tresures[_id].Name  + "!!!");            //MESSAGE
        
        DigMeter_Script.SetDigParameters(_buriedobject);
        ShowHideCursor_Script.Show();               //SHOWS CURSOR
        UI_ToActivate.SetActive(true);              //ACTIVATES DIG UI
        //DigUI.SetActive(false);//Show UI
        //Destroy(_buriedobject);        
    }
}

