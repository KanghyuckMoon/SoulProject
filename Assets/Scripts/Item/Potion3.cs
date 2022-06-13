using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion3 : IItem
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
	public string Name
	{
		get
		{
			return "Postion3";
		}
	}
	public string Description
	{
		get
		{
			return "����° ����";
		}
	}
	private int _count;

	public void UseItem(PlayerMove player)
	{
		if(_count > 0)
		{
			--_count;
			Debug.Log("���� 3 ���");
		}
		else
		{
			Debug.Log("������ �����ϴ�");
		}
	}
	public void AddCount(int add)
	{
		_count += add;
	}
}
