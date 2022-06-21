using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUICanvas : MonoBehaviour
{
	[SerializeField]
	private LockOnUI _lockOnUI;
	[SerializeField]
	private MonsterInfomationWindow _monsterInfomationWindow;

	public void Setting(IMonster obj)
	{
		_lockOnUI.Setting(obj);
		_monsterInfomationWindow.Setting(obj);
	}

	public void SelectMonsterUI(IMonster obj)
	{
		_monsterInfomationWindow.Setting(obj);
	}

	public void NoneSelectMonsterUI()
	{
		_monsterInfomationWindow.NoneSetting();
	}

	public void NoneSetting()
	{
		_lockOnUI.NoneSetting();
	}
}
