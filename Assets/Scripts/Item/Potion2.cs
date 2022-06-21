using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion2 : IItem
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
			return "Postion2";
		}
	}

	public string Description
	{
		get
		{
			return "두번째 포션";
		}
	}

	public EItem ItemType
	{
		get
		{
			return EItem.Postion2;
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

	public void UseItem(Player player)
	{
		if(Count > 0)
		{
			Debug.Log("포션 2 사용");
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
