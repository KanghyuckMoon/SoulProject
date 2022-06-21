using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterInfo : MonoBehaviour
{
	[SerializeField]
	private Image _monsterImage;
	[SerializeField]
	private Image _monsterHP;
	[SerializeField]
	private TextMeshProUGUI _levelText;

	public void Setting(IMonster monster)
	{
		_monsterImage.sprite = monster.Sprite;
		_monsterHP.sprite = monster.Sprite;
		_monsterHP.fillAmount = (float)monster.HP / monster.MaxHP;
		_levelText.text = $"LV.{monster.Level}";
		gameObject.SetActive(true);
	}

	public void NoneSetting()
	{
		gameObject.SetActive(false);
	}
}
