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
	private Image _itemImage;
	[SerializeField]
	private TextMeshProUGUI _countText;
	[SerializeField]
	private IItem _iItem;
	[SerializeField]
	private Button _button;

	public void Setting(IItem iItem, Action<ItemBox> action)
	{
		_iItem = iItem;
		_countText.text = $"{_iItem.Count}";
		_itemImage.sprite = Resources.Load<Sprite>($"Item/{_iItem.Name}");
		_button.onClick.RemoveAllListeners();
		_button.onClick.AddListener(() => action(this));
		gameObject.SetActive(true);
	}

	public void UpdateUI()
	{
		if(_iItem != null)
		{
			_countText.text = $"{_iItem.Count}";
		}
	}
}
