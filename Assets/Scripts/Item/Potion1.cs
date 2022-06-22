using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion1 : IItem
{
	public int Price
	{
		get
		{
			return _price;
		}
		set
		{
			_price = value;
		}
	}
	public int Count
	{
		get
		{
			return _itemData._count;
		}
		set
		{
			_itemData._count = value;
		}
	}
	public string Name 
	{
		get
		{
			return "Postion1";
		}
	}
	public string Description
	{
		get
		{
			return "첫번째 포션";
		}
	}
	public EItem ItemType
	{
		get
		{
			return EItem.Postion1;
		}
	}
	public ItemData ItemData
	{
		get
		{
			return _itemData;
		}
	}

	private ItemData _itemData = null;
	private int _price = 10;
	public void UseItem(Player player)
	{
		if(Count > 0)
		{
			player.GetComponent<PlayerStat>().AddHP(10);
			Count--;
			Debug.Log("포션 1 사용");
		}
		else
		{
			Debug.Log("포션이 없습니다");
		}
	}

	public void AddCount(int add)
	{
		Count += add;
	}

	public void SetItemData(ItemData itemData)
	{
		_itemData = itemData;
	}
}
