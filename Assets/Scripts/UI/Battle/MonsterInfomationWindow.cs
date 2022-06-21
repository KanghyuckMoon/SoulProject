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

	public void Setting(IMonster monster)
	{
		_nameText.text = monster.Name;
		_levelText.text = $"{monster.Level}";
		hpBar.fillAmount = (float)monster.HP / monster.MaxHP;
		gameObject.SetActive(true);
	}

	public void NoneSetting()
	{
		gameObject.SetActive(false);
	}

}
