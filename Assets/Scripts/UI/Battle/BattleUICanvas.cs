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
	[SerializeField]
	private MonsterInfo _monsterInfo;
	[SerializeField]
	private SoulInfo _soulInfo;

	public void Setting(IMonster obj, PlayerStat playerStat)
	{
		_lockOnUI.Setting(obj);
		_monsterInfomationWindow.Setting(obj, playerStat);
	}

	/// <summary>
	/// 스킬 UI 설정
	/// </summary>
	/// <param name="monster"></param>
	public void SettingSkillUI(IMonster monster)
	{
		_skillUI.Setting(monster);
	}

	/// <summary>
	/// 영혼 정보 세팅
	/// </summary>
	/// <param name="playerStat"></param>
	public void SettingSoulInfo(PlayerStat playerStat)
	{
		_soulInfo.Setting(playerStat);
	}

	/// <summary>
	/// 영혼 정보 UI 지우기
	/// </summary>
	/// <param name="playerStat"></param>
	public void NoneSettingSoulInfo()
	{
		_soulInfo.NoneSetting();
	}

	/// <summary>
	/// 몬스터 정보 UI 설정
	/// </summary>
	/// <param name="monster"></param>
	public void SettingMonsterInfo(IMonster monster)
	{
		_monsterInfo.Setting(monster);
	}

	/// <summary>
	/// 몬스터 정보UI 설정 지우기
	/// </summary>
	public void NoneSettingMonsterInfo()
	{
		_monsterInfo.NoneSetting();
	}


	public void SelectMonsterUI(IMonster obj, PlayerStat playerStat)
	{
		_monsterInfomationWindow.Setting(obj, playerStat);
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
