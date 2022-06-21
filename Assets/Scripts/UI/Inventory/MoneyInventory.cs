using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyInventory : MonoBehaviour
{
	//µ·
	[SerializeField]
	private Canvas _moneyCanvas;
	[SerializeField]
	private TextMeshProUGUI _moneyText;

	[SerializeField]
	private MoneySO _playerMoney;

	public void UpdateUI()
	{
		_moneyText.text = $"{_playerMoney._money}";
	}

	public void SetActiveMoenyCanvas(bool isboolean)
	{
		_moneyCanvas.gameObject.SetActive(isboolean);
		UpdateUI();
	}

}
