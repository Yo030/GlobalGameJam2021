using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public float BatteryLife;
    [SerializeField] private GameObject LoseUI;
    private ThirdPersonController ThirdPersonControllerScript;

    private void Start()
    {
        ThirdPersonControllerScript = FindObjectOfType<ThirdPersonController>();
    }

    private void Update()
    {
        if(BatteryLife <= 0)
        {
            ThirdPersonControllerScript.CanMove = false;
            LoseUI.SetActive(true);
        }
    }

    public void ReduceBatteryLife()
    {
        BatteryLife -= 1 * Time.deltaTime;
    }
}
