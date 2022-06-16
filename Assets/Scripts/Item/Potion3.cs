using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion3 : IItem
{
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
			return "Postion3";
		}
	}
	public string Description
	{
		get
		{
			return "세번째 포션";
		}
	}
	public EItem ItemType
	{
		get
		{
			return EItem.Postion3;
		}
	}
	public ItemData ItemData
	{
		get
		{
			return _itemData;
		}
	}
	private ItemData _itemData;

	public void UseItem(PlayerMove player)
	{
		if(Count > 0)
		{
			--Count;
			Debug.Log("포션 3 사용");
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
