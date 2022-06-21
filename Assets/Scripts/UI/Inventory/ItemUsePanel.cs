using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUsePanel : MonoBehaviour
{
	[SerializeField]
	protected RectTransform _itemCommandPanel;
	[SerializeField]
	protected Button _panelButton;
	[SerializeField]
	protected Button _useButton;
	[SerializeField]
	protected Button _chunkButton;
	[SerializeField]
	protected Button _cancelButton;
	[SerializeField]
	protected ItemInventory _inventory;
	[SerializeField]
	protected ItemInfomation _itemInfomation;

	protected ItemBox _itemBox;

	public void Start()
	{
		_useButton.onClick.AddListener(() => Use());
		_chunkButton.onClick.AddListener(() => Chunk());
		_cancelButton.onClick.AddListener(() => Cancel());
		_panelButton.onClick.AddListener(() => Cancel());
	}

	public void Setting(ItemBox itemBox)
	{
		_itemBox = itemBox;
		Vector2 pos = _itemBox.GetComponent<RectTransform>().position;
		pos.y -= 100;
		_itemCommandPanel.position = pos;
		gameObject.SetActive(true);
	}
	protected virtual void Use()
	{
		_itemBox.Item.UseItem(_inventory.Player);
		_inventory.UpdateUI();
		gameObject.SetActive(false);
		_itemInfomation.NoneSetting();

		if(_itemBox.Item.Count <= 0)
		{
			Chunk();
		}
	}

	protected virtual void Chunk()
	{
		_inventory.RemoveItem(_itemBox);
		_inventory.UpdateUI();
		gameObject.SetActive(false);
		_itemInfomation.NoneSetting();
	}

	protected virtual void Cancel()
	{
		gameObject.SetActive(false);
		_itemInfomation.NoneSetting();
	}

}
