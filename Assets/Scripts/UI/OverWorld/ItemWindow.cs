using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemWindow : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _nameText;
	private Camera _mianCamera;
	private RectTransform _rectTransform;

	public void Start()
	{
		_rectTransform = GetComponent<RectTransform>();
		_mianCamera = Camera.main;
	}


	public void Setting(ItemObject itemObj)
	{
		Vector3 point = _mianCamera.WorldToScreenPoint(itemObj.transform.position);
		point.y += 150;
		_rectTransform.position = point;
		_nameText.text = itemObj.Item.Name;
		gameObject.SetActive(true);
	}

	public void NoneSetting()
	{
		gameObject.SetActive(false);
	}
}
