using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInventory : MonoBehaviour
{
	public PlayerMove Player
	{
		get
		{
			if(_playerMove == null)
			{
				_playerMove = FindObjectOfType<PlayerMove>();
			}
			return _playerMove;

		}
	}

	private List<IItem> _items = new List<IItem>();
	private List<ItemBox> _itemBoxs = new List<ItemBox>();
	private PlayerMove _playerMove = new PlayerMove();

	//인벤토리 패널 관련
	[SerializeField]
	private GameObject _itemBox;
	[SerializeField]
	private Transform _itemBoxParent;
	[SerializeField]
	private ItemInfomation _itemInfomation;
	[SerializeField]
	private ItemUsePanel _itemUsePanel;


	private void Start()
	{
		Potion1 potion1 = new Potion1();
		potion1.Count = 3;
		Potion2 potion2 = new Potion2();
		potion2.Count = 3;
		Potion3 potion3 = new Potion3();
		potion3.Count = 3;
		AddItem(potion1);
		AddItem(potion2);
		AddItem(potion3);
	}

	public void RemoveItem(ItemBox itembox)
	{
		_items.Remove(_items.Find(x => x.Name == itembox.Item.Name));
		_itemBoxs.Remove(itembox);
		itembox.gameObject.SetActive(false);
	}

	public void AddItem(IItem iItem)
	{
		IItem item = _items.Find(x => x.Name == iItem.Name);
		if(item != null)
		{
			item.AddCount(iItem.Count);
			_itemBoxs.Find(x => x.Item == item).UpdateUI();
		}
		else
		{
			ItemBox itembox = PoolItemBox();
			itembox.Setting(iItem, OnItemInfomation);
			_itemBoxs.Add(itembox);
		}
	}

	public void UpdateUI()
	{
		int count = _itemBoxs.Count;
		for (int i = 0; i < count; ++i)
		{
			_itemBoxs[i].UpdateUI();
		}
		_itemInfomation.UpdateUI();
	}

	private void OnItemInfomation(ItemBox itembox)
	{
		_itemInfomation.Setting(itembox);
		_itemUsePanel.Setting(itembox);
	}

	private ItemBox PoolItemBox()
	{
		for(int i = 0; i < _itemBoxParent.childCount; ++i)
		{
			if(!_itemBoxParent.GetChild(i).gameObject.activeSelf)
			{
				return _itemBoxParent.GetChild(i).GetComponent<ItemBox>();
			}
		}
		return Instantiate(_itemBox, _itemBoxParent).GetComponent<ItemBox>();
	}
}
