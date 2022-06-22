using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoulPanel : MonoBehaviour
{
	private PlayerStat PlayerStat
	{
		get
		{
			_playerStat ??= FindObjectOfType<PlayerStat>();
			return _playerStat;
		}
	}

	[SerializeField]
	private TextMeshProUGUI _levelText;
	[SerializeField]
	private TextMeshProUGUI _hpText;
	[SerializeField]
	private TextMeshProUGUI _spdText;
	[SerializeField]
	private TextMeshProUGUI _defText;
	[SerializeField]
	private TextMeshProUGUI _expText;
	[SerializeField]
	private Image _hpImage;
	[SerializeField]
	private Image _expImage;

	private PlayerStat _playerStat = null;

	public void OnEnable()
	{
		Setting(PlayerStat);
	}

	public void Setting(PlayerStat playerStat)
	{
		_levelText.text = $"LV.{playerStat.Level}";
		_hpText.text = $"HP: {playerStat.MaxHP}";
		_spdText.text = $"SPD: {playerStat.SPD}";
		_defText.text = $"DEF: {playerStat.DEF}";
		_expText.text = $"EXP) {playerStat.Exp}/{playerStat.Level * 10}";
		_hpImage.fillAmount = (float)(playerStat.MaxHP - playerStat.HP) / playerStat.MaxHP;
		_expImage.fillAmount = playerStat.Exp / playerStat.Level * 10;
	}

}
