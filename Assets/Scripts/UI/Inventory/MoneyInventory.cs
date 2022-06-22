using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoonLibrary.DesignPattern;

public class MoneyInventory : MonoBehaviour, IObserver
{
	//µ·
	[SerializeField]
	private Canvas _moneyCanvas;
	[SerializeField]
	private TextMeshProUGUI _moneyText;

	[SerializeField]
	private MoneySO _playerMoney;

	private void Start()
	{
		_playerMoney.AddObserver(this);
	}

	public void UpdateUI()
	{
		_moneyText.text = $"{_playerMoney._money}";
	}

	public void SetActiveMoenyCanvas(bool isboolean)
	{
		_moneyCanvas.gameObject.SetActive(isboolean);
		UpdateUI();
	}

	public void GetNotify()
	{
		UpdateUI();
	}
}
