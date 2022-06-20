using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemBox : MonoBehaviour
{
	public IItem Item
	{
		get
		{
			return _iItem;
		}
	}
	public Sprite ItemSprite
	{
		get
		{
			return _itemImage.sprite;
		}
	}

	[SerializeField]
	private EventTrigger _eventTrigger;
	[SerializeField]
	private Image _itemImage;
	[SerializeField]
	private TextMeshProUGUI _countText;
	[SerializeField]
	private IItem _iItem;

	private Action<ItemBox> _clickAction;
	private Action<ItemBox> _onAction;

	public void Setting(IItem iItem, Action<ItemBox> clickAction, Action<ItemBox> onAction, bool isShop = false)
	{
		UpdateUI(iItem, isShop);
		   _clickAction = clickAction;
		_onAction = onAction;
		gameObject.SetActive(true);
	}

	public void OnClick()
	{
		_clickAction.Invoke(this);
	}

	public void OnMouseOn()
	{
		_onAction.Invoke(this);
	}

	public void UpdateUI(IItem iItem, bool isShop)
	{
		_iItem = iItem;
		if(isShop)
		{
			_countText.text = $"";
		}
		else
		{
			_countText.text = $"{_iItem.Count}";
		}
		_itemImage.sprite = Resources.Load<Sprite>($"Item/{_iItem.Name}");
	}
}
