using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Store : MonoBehaviour
{
    public static Store instance;
	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	public List<StoreItems> StoreItemsList;
	[SerializeField] GameObject ItemTemplate;
	GameObject g;
	[SerializeField] Transform ShopScrollView;
	[SerializeField] GameObject ShopPanel;
	Button buyBtn;
	/*
	private void Start()
	{
		int len = ShopItemsList.Count;
		for (int i = 0; i < len; i++)
		{
			g = Instantiate(ItemTemplate, ShopScrollView);
			g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
			g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
			buyBtn = g.transform.GetChild(2).GetComponent<Button>();
			if (ShopItemsList[i].IsPurchased)
			{
				DisableBuyButton();
			}
			buyBtn.AddEventListener(i, OnShopItemBtnClicked);
		}
	}*/
}
