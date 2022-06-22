using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteraction
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
	public string InteractionName
	{
		get
		{
			return "포션1";
		}
	}

	public string InteractionActionName
	{
		get
		{
			return "줍기";
		}
	}

	public Transform Transform
	{
		get
		{
			return transform;
		}
	}


	protected IItem _item;

	private void Start()
	{
		ItemData itemData= new ItemData();
		itemData._itemType = EItem.Postion1;
		itemData._count = 3;
		Setting(new Potion1(), itemData);
	}

	public void Setting(IItem item, ItemData itemData)
	{
		_item = item;
		_item.SetItemData(itemData);
	}

	public void Interaction(Player player)
	{
		player.AddItem(_item);
	}
}
