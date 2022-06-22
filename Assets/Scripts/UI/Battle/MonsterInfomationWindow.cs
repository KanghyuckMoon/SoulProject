using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterInfomationWindow : MonoBehaviour
{
	[SerializeField]
	private Image hpBar;
	[SerializeField]
	private Image hpMaxBar;
	[SerializeField]
	private TextMeshProUGUI _levelText;
	[SerializeField]
	private TextMeshProUGUI _nameText;
	[SerializeField]
	private TextMeshProUGUI _captureText;

	public void Setting(IMonster monster, PlayerStat playerStat)
	{
		_nameText.text = monster.Name;
		_levelText.text = $"LV.{monster.Level}";
		hpBar.fillAmount = (float)monster.HP / monster.MaxHP;
		if (playerStat.Level >= monster.Level)
		{
			_captureText.text = "빙의 가능";
		}
		else
		{
			_captureText.text = "빙의 불가능";
		}
		gameObject.SetActive(true);
	}

	public void NoneSetting()
	{
		gameObject.SetActive(false);
	}

}
