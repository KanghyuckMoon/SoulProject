using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextAtkEffect : MonoBehaviour
{
	private TextMeshPro _text;
	private ItemPool _itemPool;

	public void Setting(int damage)
	{
		_text ??= GetComponent<TextMeshPro>();
		_itemPool ??= FindObjectOfType<ItemPool>();
		gameObject.SetActive(true);

		_text.text = $"{damage}";

		transform.LookAt(Camera.main.transform);
		float moveY = transform.position.y;
		moveY += 5;
		transform.DOMoveY(moveY, 1f).OnComplete(() => 
		{
			_itemPool.RegisterObject<TextAtkEffect>(this);
			gameObject.SetActive(false);
		});
	}
}
