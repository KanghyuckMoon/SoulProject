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
			_text.color = new Color(0.79f,0.8f,0.87f);
		}
		else if(damage <= 20)
		{
			_text.fontSize = 10;
			_text.color = new Color(1,1,1);
		}
		else if (damage <= 50)
		{
			_text.fontSize = 12;
			_text.color = new Color(0.96f, 0.92f, 0.48f);
		}
		else if (damage <= 100)
		{
			_text.fontSize = 15;
			_text.color = new Color(0.96f, 0.5f, 0.03f);
		}
		else
		{
			_text.fontSize = 20;
			_text.color = new Color(0.96f, 0.27f, 0.09f);
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
