using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SoulInfo : MonoBehaviour
{
	[SerializeField]
	private Image _soulImage;
	[SerializeField]
	private Image _soulHP;
	[SerializeField]
	private TextMeshProUGUI _levelText;

	public void Setting(PlayerStat playerStat)
	{
		_soulHP.fillAmount = (float)playerStat.HP / playerStat.MaxHP;
		_levelText.text = $"LV.{playerStat.Level}";
		gameObject.SetActive(true);
	}

	public void NoneSetting()
	{
		gameObject.SetActive(false);
	}
}
