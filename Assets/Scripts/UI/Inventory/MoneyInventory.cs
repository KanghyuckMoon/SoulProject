using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyInventory : MonoBehaviour
{
	//��
	[SerializeField]
	private Canvas _moneyCanvas;
	[SerializeField]
	private TextMeshProUGUI _moneyText;

	[SerializeField]
	private int _money;
	[SerializeField]
	private int _crystal;

	[ContextMenu("��UI ������Ʈ")]
	private void UpdateUI()
	{
		_moneyText.text = $"{_money}";
	}

	public void SetActiveMoenyCanvas(bool isboolean)
	{
		_moneyCanvas.gameObject.SetActive(isboolean);
	}
	public void AddMoney(int add)
	{
		_money += add;

		UpdateUI();
	}

}
