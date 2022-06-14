using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoticeItem : MonoBehaviour
{
	[SerializeField]
	private Image _itemImage = null;
	[SerializeField]
	private TextMeshProUGUI _nameText;
	[SerializeField]
	private TextMeshProUGUI _countText;
	//
	private WaitForSeconds _waitForSeconds;
	public void Start()
	{
		_waitForSeconds = new WaitForSeconds(1);
	}

	public void Setting(IItem item)
	{
		transform.SetAsLastSibling();
		_itemImage.sprite = Resources.Load<Sprite>($"Item/{item.Name}");
		_nameText.text = item.Name;
		_countText.text = $"x{item.Count}";
		gameObject.SetActive(true);
		StartCoroutine(WaitClose());
	}

	public void Setting(int money)
	{
		transform.SetAsLastSibling();
		_itemImage.sprite = Resources.Load<Sprite>($"Item/Money");
		_nameText.text = "Money";
		_countText.text = $"x{money}";
		gameObject.SetActive(true);
		StartCoroutine(WaitClose());
	}


	private IEnumerator WaitClose()
	{
		yield return _waitForSeconds;
		gameObject.SetActive(false);
	}
}
