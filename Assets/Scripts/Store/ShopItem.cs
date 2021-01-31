using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Name_TXT;
    [SerializeField] private TextMeshProUGUI Price_TXT;
    [SerializeField] private TextMeshProUGUI Money_TXT;
    [Space]
    [SerializeField] private Inventory Inventory_Script;
    [SerializeField] private Battery Battery_Script;
    [SerializeField] private ShowHideCursor ShowHideCursor_Script;
    [SerializeField] private GameObject Shop_UI;
    [Space]
    [SerializeField] private AudioManager AudioManager_Script;

    [SerializeField] private int Price;
    private Button ThisButtom;

    private void Start()
    {
        UpdateMyMoney();
        Price_TXT.text = "$" + Price.ToString();
    }

    public void BuyItem(int _itemnum)
    {
        if(VariableManager.instance.Money >= Price)
        {
            AudioManager_Script.play("Baught", 1);
            if (_itemnum == 3 && VariableManager.instance.MaxInventorySlots == 4)
            {
                ThisButtom = GetComponent<Button>();
                ThisButtom.interactable = false;
            }
            VariableManager.instance.Money -= Price;
            UpdateMyMoney();
            Buy(_itemnum);
        }
        else
        {
            AudioManager_Script.play("Nope", 1);
            Debug.Log("Can't Buy");
        }
    }
    public void UpdateMyMoney()
    {
        Money_TXT.text = "$" + VariableManager.instance.Money.ToString();
    }

    private void Buy(int _itemnum)
    {
        switch (_itemnum)
        {
            case 1:
                Battery_Script.AddBatteryPower();
                Debug.Log("Battery Power++");
                break;



            case 3:
                Inventory_Script.ReloadSlots(1);
                Debug.Log("+1 Slot");
                break;
            case 4:
                UpdateMyMoney();
                Debug.Log("SkinChange");
                break;
            default:
                Debug.Log("You Got Nothing");
                break;
        }
    }

    public void ExitStore()
    {
        Shop_UI.SetActive(false);
        ShowHideCursor_Script.Hide();
    }
}
