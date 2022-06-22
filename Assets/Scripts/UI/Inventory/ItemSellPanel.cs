using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSellPanel : ItemUsePanel
{
	[SerializeField]
	private MoneySO _moneySO;

	protected override void Use()
	{
		_moneySO.AddMoney(_itemBox.Item.Price);
		_itemBox.Item.AddCount(-1);
		_inventory.UpdateUI();
		gameObject.SetActive(false);
		_itemInfomation.Setting(_itemBox);

		if (_itemBox.Item.Count <= 0)
		{
			Chunk();
			_itemInfomation.NoneSetting();
		}
	}
}
