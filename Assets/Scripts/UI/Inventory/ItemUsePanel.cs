using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUsePanel : MonoBehaviour
{
	[SerializeField]
	private RectTransform _itemCommandPanel;
	[SerializeField]
	private Button _panelButton;
	[SerializeField]
	private Button _useButton;
	[SerializeField]
	private Button _chunkButton;
	[SerializeField]
	private Button _cancelButton;
	[SerializeField]
	private ItemInventory _inventory;
	[SerializeField]
	private ItemInfomation _itemInfomation;

	private ItemBox _itemBox;

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
	private void Use()
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

	private void Chunk()
	{
		_inventory.RemoveItem(_itemBox);
		_inventory.UpdateUI();
		gameObject.SetActive(false);
		_itemInfomation.NoneSetting();
	}

	private void Cancel()
	{
		gameObject.SetActive(false);
		_itemInfomation.NoneSetting();
	}

}
