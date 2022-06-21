using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUICanvas : MonoBehaviour
{
	[SerializeField]
	private LockOnUI _lockOnUI;
	[SerializeField]
	private MonsterInfomationWindow _monsterInfomationWindow;
	[SerializeField]
	private SkillUI _skillUI;

	public void Setting(IMonster obj)
	{
		_lockOnUI.Setting(obj);
		_monsterInfomationWindow.Setting(obj);
	}

	/// <summary>
	/// 스킬 UI 설정
	/// </summary>
	/// <param name="monster"></param>
	public void SettingSkillUI(IMonster monster)
	{
		_skillUI.Setting(monster);
	}

	public void SelectMonsterUI(IMonster obj)
	{
		_monsterInfomationWindow.Setting(obj);
	}

	public void NoneSelectMonsterUI()
	{
		_monsterInfomationWindow.NoneSetting();
	}
	
	public void NoneSettingSkillUI()
	{
		_skillUI.NoneSetting();
	}

	public void NoneSetting()
	{
		_lockOnUI.NoneSetting();
	}
}
