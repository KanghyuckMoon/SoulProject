using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion2 : IItem
{
	public int Count
	{
		get
		{
			return _count;
		}
		set
		{
			_count = value;
		}
	}
	private int _count;

	public void UseItem()
	{
		if(_count > 0)
		{
			--_count;
			Debug.Log("���� 2 ���");
		}
		else
		{
			Debug.Log("������ �����ϴ�");
		}
	}
}
