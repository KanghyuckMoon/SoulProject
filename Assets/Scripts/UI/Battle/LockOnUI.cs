using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockOnUI : MonoBehaviour
{
	private Camera _mianCamera;
	private RectTransform _rectTransform;


	public void Start()
	{
		_rectTransform = GetComponent<RectTransform>();
		_mianCamera = Camera.main;
		NoneSetting();
	}

	public void Setting(IMonster obj)
	{
		Vector3 point = _mianCamera.WorldToScreenPoint(obj.Position);
		point.y += 150;
		_rectTransform.position = point;
		gameObject.SetActive(true);
	}

	public void NoneSetting()
	{
		gameObject.SetActive(false);
	}

}
