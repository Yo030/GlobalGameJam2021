using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dig : MonoBehaviour
{
    [SerializeField] private GameObject UI_ToActivate;
    [SerializeField] private ShowHideCursor ShowHideCursor_Script;
        
    private GameObject DigUI_Text;

    /*
    public void ShowDigUI(bool _show)
    {
        DigUI.SetActive(_show);//Show UI
    }*/

    public void DiscoverTresure(GameObject _buriedobject)
    {        
        Debug.Log("YOU JUST DIGGED!!!");            //MESSAGE
        ShowHideCursor_Script.Show();               //SHOWS CURSOR
        UI_ToActivate.SetActive(true);              //ACTIVATES DIG UI
        //DigUI.SetActive(false);//Show UI
        //Destroy(_buriedobject);        
    }
}

