using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _actionText;

	public void Setting(IInteraction obj)
	{
		_actionText.text = obj.InteractionActionName;
		gameObject.SetActive(true);
	}

	public void NoneSetting()
	{
		gameObject.SetActive(false);
	}
}
