using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfomation : MonoBehaviour
{
	private ItemBox _itemBox;

	[SerializeField]
	private TextMeshProUGUI _nameText;
	[SerializeField]
	private TextMeshProUGUI _descriptionText;
	[SerializeField]
	private TextMeshProUGUI _countText;
	[SerializeField]
	private TextMeshProUGUI _priceText;
	[SerializeField]
	private Image _itemImage;

	private void Start()
	{
		NoneSetting();
	}

	public void Setting(ItemBox itemBox)
	{
		_itemBox = itemBox;
		UpdateUI();
	}

	public void UpdateUI()
	{
		if(_itemBox == null)
		{
			NoneSetting();
		}
		else
		{
			_nameText.text = _itemBox.Item.Name;
			_descriptionText.text = _itemBox.Item.Description;
			_countText.text = $"{_itemBox.Item.Count}";
			_priceText.text = $"°¡Ä¡ : {_itemBox.Item.Price}";
			_itemImage.sprite = _itemBox.ItemSprite;
			_itemImage.color = new Color(1, 1, 1, 1);
		}
	}

	public void NoneSetting()
	{
		_itemBox = null;
		_nameText.text = "";
		_countText.text = "";
		_descriptionText.text = "";
		_priceText.text = "";
		_itemImage.sprite = null;
		_itemImage.color = new Color(1,1,1,0);
	}
}
