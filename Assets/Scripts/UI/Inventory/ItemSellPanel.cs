using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSellPanel : ItemUsePanel
{
	protected override void Use()
	{
		_itemBox.Item.UseItem(_inventory.Player);
		_inventory.UpdateUI();
		gameObject.SetActive(false);
		_itemInfomation.NoneSetting();

		if (_itemBox.Item.Count <= 0)
		{
			Chunk();
		}
	}
}
