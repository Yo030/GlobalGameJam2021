using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BatteryUI : MonoBehaviour
{
    [SerializeField] private Battery Battery_Script;
    private Image MyImage;

    private void Start()
    {
        MyImage = GetComponent<Image>();
    }

    private void Update()
    {
        MyImage.fillAmount = Battery_Script.BatteryLife / VariableManager.instance.MaxBattery;
    }
}
