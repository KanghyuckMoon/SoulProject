using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

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

	private ItemPool ItemPool
	{
		get
		{
			_itemPool ??= FindObjectOfType<ItemPool>();
			return _itemPool;
		}
		set
		{
			_itemPool = value;
		}
	}

	private ItemPool _itemPool;

	public void Setting(IItem item, ItemData itemData, Vector3 pos)
	{
		_item = item;
		_item.SetItemData(itemData);
		transform.position = pos;

		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		if(spriteRenderer == null)
		{
			spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		}
		spriteRenderer.sprite = Resources.Load<Sprite>($"Item/{item.Name}");
		transform.DORotate(new Vector3(0, -360, 0), 5f, RotateMode.FastBeyond360);
		transform.localScale = Vector3.one * 0.5f;
		gameObject.tag = "Item";

		gameObject.SetActive(true);
	}

	public void Interaction(Player player)
	{
		player.AddItem(_item);
		ItemPool.RegisterObject<ItemObject>(this);
		player.DOKill();
		gameObject.SetActive(false);
	}
}
