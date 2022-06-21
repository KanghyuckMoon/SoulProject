using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUI : MonoBehaviour
{
	[SerializeField]
	private Image _SkillMLB;
	[SerializeField]
	private Image _SkillMRB;
	[SerializeField]
	private Image _SKillE;
	[SerializeField]
	private Image _SkillR;

	public void Setting(IMonster monster)
	{
		_SkillMLB.gameObject.SetActive(monster.CheckCanMLB());
		_SkillMRB.gameObject.SetActive(monster.CheckCanMRB());
		_SKillE.gameObject.SetActive(monster.CheckCanE());
		_SkillR.gameObject.SetActive(monster.CheckCanR());

		_SkillMLB.fillAmount = monster.CoolTimeMLB;
		_SkillMRB.fillAmount = monster.CoolTimeMRB;
		_SKillE.fillAmount = monster.CoolTimeE;
		_SkillR.fillAmount = monster.CoolTimeR;

		gameObject.SetActive(true);
	}

	public void NoneSetting()
	{
		gameObject.SetActive(false);
	}
}
