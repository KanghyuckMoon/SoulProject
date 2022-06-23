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
		if(damage <= 3)
		{
			_text.fontSize = 5;
		}
		else if(damage <= 20)
		{
			_text.fontSize = 10;
		}
		else if (damage <= 50)
		{
			_text.fontSize = 12;
		}
		else if (damage <= 100)
		{
			_text.fontSize = 15;
		}
		else
		{
			_text.fontSize = 20;
		}

		transform.LookAt(Camera.main.transform);
		float moveY = transform.position.y;
		moveY += 3;
		transform.DOMoveY(moveY, 0.5f).OnComplete(() => 
		{
			_itemPool.RegisterObject<TextAtkEffect>(this);
			gameObject.SetActive(false);
		});
	}
}
