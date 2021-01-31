using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeItems : MonoBehaviour
{
    [SerializeField] private Inventory Inventory_Script;
    [Space]
    [SerializeField] private AudioManager AudioManager_Script;

    private void OnEnable()
    {
        for(int i=0; i<VariableManager.instance.MaxInventorySlots; i++)
        {
            if(VariableManager.instance.InventoryList[i] != "")
            {
                VariableManager.instance.Money += GetMoney(VariableManager.instance.InventoryList[i]);
                VariableManager.instance.InventoryList[i] = "";
                AudioManager_Script.play("MoneyExchange", 1);
            }
        }
        Inventory_Script.ReloadSlots(0);
    }

    private int GetMoney(string _tresurename)
    {
        switch(_tresurename)
        {
            case "Lata":
                return 2;
            case "Corcholata":
                return 3;
            case "Moneda":
                return 3;
            case "Ansuelo":
                return 3;
            case "Pila":
                return 3;
            case "LLave":
                return 5;
            case "Anillo":
                return 15;
            case "Reloj":
                return 50;
            case "Bala":
                return 120;
            case "Mina":
                return 200;
            case "Cofre":
                return 500;
            default:
                return 1;
        }
    }
}
