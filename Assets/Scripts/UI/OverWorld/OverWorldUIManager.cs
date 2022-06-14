using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorldUIManager : MonoBehaviour
{
	[SerializeField]
	private InteractionUI _interactionUI;
	[SerializeField]
	private ItemWindow _itemWindow;

	public void Setting(ItemObject itemObj)
	{
		_interactionUI.Setting();
		_itemWindow.Setting(itemObj);
	}

	public void NoneSetting()
	{
		_interactionUI.NoneSetting();
		_itemWindow.NoneSetting();
	}
}
