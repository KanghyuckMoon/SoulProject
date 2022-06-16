using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
	[SerializeField]
	protected int _count;

	public IItem Item
	{
		get
		{
			return _item;
		}
	}

	protected IItem _item;

	private void Start()
	{
		ItemData itemData= new ItemData();
		itemData._itemType = EItem.Postion1;
		itemData._count = 3;
		_item = new Potion1();
		_item.SetItemData(itemData);
	}
}
