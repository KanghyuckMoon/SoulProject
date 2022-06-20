using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
	public MoneyInventory MoneyInventory
	{
		get
		{
			if(_moneyInventory == null)
			{
				_moneyInventory = FindObjectOfType<MoneyInventory>();
			}
			return _moneyInventory;
		}
	}

	private MoneyInventory _moneyInventory;
	private List<IItem> _buyItems = new List<IItem>();
	private List<ItemBox> _itemBoxs = new List<ItemBox>();

	[SerializeField]
	private Canvas _shopCanvas = null;
	[SerializeField]
	private GameObject _itemBoxPrefeb;
	[SerializeField]
	private Transform _itemBoxParent;
	[SerializeField]
	private ItemInfomation _itemInfomation;
	[SerializeField]
	private ItemSetSO _sellItems;

	private Player _player = null;
	private Merchant _merchant = null;

	public void Update()
	{
		if(_shopCanvas.gameObject.activeSelf)
		{
			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				NoneSetting();
			}
		}
	}

	public void Setting(Player player, Merchant merchant, ItemSetSO itemSetSO)
	{
		_player = player;
		_merchant = merchant;
		_buyItems = itemSetSO.GetIItemList();
		_player.IsCantAnything = true;
		SetActiveCanvas(true);
		UpdateUI(true);
	}
	
	public void NoneSetting()
	{
		_merchant.EndTrade();
		_player.IsCantAnything = false;
		SetActiveCanvas(false);
	}

	public void OnBuyTab()
	{
		UpdateUI(true);
	}

	public void OnSellTab()
	{
		UpdateUI(false);
	}

	public void OnItemInfomation(ItemBox itembox)
	{
		_itemInfomation.Setting(itembox);
	}

	public void UpdateUI(bool isBuy)
	{
		//아이템 박스 초기화
		int itemCount = 0;
		_itemBoxs.Clear();
		for (int i = 0; i < _itemBoxParent.childCount; ++i)
		{
			_itemBoxParent.GetChild(i).gameObject.SetActive(false);
		}

		if (isBuy) //아이템 구매
		{
			//아이템의 갯수 설정
			itemCount = _buyItems.Count;
			for (int i = 0; i < itemCount; ++i)
			{
				ItemBox itembox = PoolItemBox();
				itembox.Setting(_buyItems[i], BuyItem, OnItemInfomation, true);
				_itemBoxs.Add(itembox);
			}
		}
		else //아이템 판매
		{
			//아이템의 갯수 설정
			List<IItem> items = _sellItems.GetIItemList();
			itemCount = items.Count;

			for (int i = 0; i < itemCount; ++i)
			{
				ItemBox itembox = PoolItemBox();
				itembox.Setting(items[i], SellItem, OnItemInfomation);
				_itemBoxs.Add(itembox);
			}
		}

		
		_itemInfomation.UpdateUI();
	}

	private void SetActiveCanvas(bool isboolean)
	{
		_shopCanvas.gameObject.SetActive(isboolean);
		MoneyInventory.SetActiveMoenyCanvas(isboolean);
		if (isboolean)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	private void BuyItem(ItemBox item)
	{
		_player.AddItem(item.Item);
	}

	private void SellItem(ItemBox item)
	{
		Debug.Log("아이템 판매");
	}

	/// <summary>
	/// 아이템 박스 풀링
	/// </summary>
	/// <returns></returns>
	private ItemBox PoolItemBox()
	{
		for (int i = 0; i < _itemBoxParent.childCount; ++i)
		{
			if (!_itemBoxParent.GetChild(i).gameObject.activeSelf)
			{
				return _itemBoxParent.GetChild(i).GetComponent<ItemBox>();
			}
		}
		return Instantiate(_itemBoxPrefeb, _itemBoxParent).GetComponent<ItemBox>();
	}
}
