using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dig : MonoBehaviour
{
    [SerializeField] private GameObject DigUI;
    /*
    public void ShowDigUI(bool _show)
    {
        DigUI.SetActive(_show);//Show UI
    }*/

    public void DiscoverTresure(GameObject _buriedobject)
    {
        Debug.Log("YOU JUST DIGGED!!!");
        DigUI.SetActive(false);//Show UI
        Destroy(_buriedobject);        
    }
}

