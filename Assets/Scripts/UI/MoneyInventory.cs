using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyInventory : MonoBehaviour
{
	//µ·
	[SerializeField]
	private TextMeshProUGUI _moneyText;
	[SerializeField]
	private TextMeshProUGUI _crystalText;

	[SerializeField]
	private int _money;
	[SerializeField]
	private int _crystal;

	[ContextMenu("µ·UI ¾÷µ¥ÀÌÆ®")]
	public void UpdateUI()
	{
		_moneyText.text = $"{_money}";
		_crystalText.text = $"{_crystal}";
	}

}
