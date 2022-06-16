using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSetSO",menuName = "ScriptableObject/ItemSetSO")]
public class ItemSetSO : ScriptableObject
{
	public List<ItemData> _itemsList;
	
	public List<IItem> GetIItemList()
	{
		var items = new List<IItem>();
		var count = _itemsList.Count;
		
		for(int i = 0; i < count; ++i)
		{
			items.Add(ChangeIItem(_itemsList[i]));
		}

		return items;
	}

	public void AddItem(EItem itemType, int count)
	{
		ItemData itemData = _itemsList.Find(x => x._itemType == itemType);
		if(itemData != null)
		{
			itemData._count += count;
		}
		else
		{
			itemData = new ItemData();
			itemData._itemType = itemType;
			itemData._count = count;
			_itemsList.Add(itemData);
		}
	}

	public void RemoveItem(EItem itemType)
	{
		_itemsList.Remove(_itemsList.Find(x => x._itemType == itemType));
	}

	public IItem FindItem(EItem itemType)
	{
		return ChangeIItem(_itemsList.Find(x => x._itemType == itemType));
	}
	public ItemData FindItemData(EItem itemType)
	{
		return _itemsList.Find(x => x._itemType == itemType);
	}


	private IItem ChangeIItem(ItemData itemData)
	{
		IItem item = null;
		switch (itemData._itemType)
		{
			case EItem.None:
				Debug.LogError("잘못된 타입");
				break;
			case EItem.Postion1:
				item = new Potion1();
				break;
			case EItem.Postion2:
				item = new Potion2();
				break;
			case EItem.Postion3:
				item = new Potion3();
				break;
		}
		item.SetItemData(itemData);
		return item;
	}
}

[System.Serializable]
public class ItemData
{
	public EItem _itemType;
	public int _count;
}