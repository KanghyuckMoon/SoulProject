using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUICanvas : MonoBehaviour
{
	[SerializeField]
	private LockOnUI _lockOnUI;

	public void Setting(IMonster obj)
	{
		_lockOnUI.Setting(obj);
	}

	public void NoneSetting()
	{
		_lockOnUI.NoneSetting();
	}
}
