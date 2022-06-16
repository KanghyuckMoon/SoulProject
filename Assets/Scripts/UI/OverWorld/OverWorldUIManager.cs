using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorldUIManager : MonoBehaviour
{
	[SerializeField]
	private InteractionUI _interactionUI;
	[SerializeField]
	private ItemWindow _itemWindow;

	public void Setting(IInteraction obj)
	{
		_interactionUI.Setting(obj);
		_itemWindow.Setting(obj);
	}

	public void NoneSetting()
	{
		_interactionUI.NoneSetting();
		_itemWindow.NoneSetting();
	}
}
