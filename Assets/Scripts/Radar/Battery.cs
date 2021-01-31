using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public float BatteryLife = 120f;
    [SerializeField] private GameObject LoseUI;
    private ThirdPersonController ThirdPersonControllerScript;
    [SerializeField] private int BatteryRechargeAmmount = 1;

    private void Start()
    {
        ThirdPersonControllerScript = FindObjectOfType<ThirdPersonController>();
    }

    private void Update()
    {
        if(BatteryLife <= 0)
        {
            ThirdPersonControllerScript.CanMove = false;
            if(LoseUI.activeSelf == false)
            {
                LoseUI.SetActive(true);
                FindObjectOfType<ShowHideCursor>().Show();
            }
        }
    }

    public void ReduceBatteryLife()
    {
        BatteryLife -= 1 * Time.deltaTime;
    }

    public void AddBatteryPower()
    {
        BatteryLife += BatteryRechargeAmmount;
    }
}
