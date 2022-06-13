using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion1 : IItem
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
			return "Postion1";
		}
	}
	public string Description
	{
		get
		{
			return "ù��° ����";
		}
	}

	private int _count;

	public void UseItem(PlayerMove player)
	{
		if(_count > 0)
		{
			player.AddHP(10);
			--_count;
			Debug.Log("���� 1 ���");
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
