using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _noticeItem;
	[SerializeField]
	private Transform _noticeParent;

	/// <summary>
	/// ¾ÆÀÌÅÛ È¹µæ½Ã ¾Ë¶÷
	/// </summary>
	/// <param name="item"></param>
	public void Notice(IItem item)
	{
		PoolItemBox().Setting(item);
	}

	/// <summary>
	/// ¾ÆÀÌÅÛ È¹µæ½Ã ¾Ë¶÷
	/// </summary>
	/// <param name="item"></param>
	public void Notice(IItem item, int count)
	{
		PoolItemBox().Setting(item, count);
	}

	/// <summary>
	/// µ· È¹µæ½Ã ¾Ë¶÷
	/// </summary>
	/// <param name="item"></param>
	public void Notice(int money)
	{
		PoolItemBox().Setting(money);
	}

	private NoticeItem PoolItemBox()
	{
		for (int i = 0; i < _noticeParent.childCount; ++i)
		{
			if (!_noticeParent.GetChild(i).gameObject.activeSelf)
			{
				return _noticeParent.GetChild(i).GetComponent<NoticeItem>();
			}
		}
		return Instantiate(_noticeItem, _noticeParent).GetComponent<NoticeItem>();
	}
}
