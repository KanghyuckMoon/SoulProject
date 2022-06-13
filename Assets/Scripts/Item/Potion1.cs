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
			return "첫번째 포션";
		}
	}

	private int _count;

	public void UseItem(PlayerMove player)
	{
		if(_count > 0)
		{
			player.AddHP(10);
			--_count;
			Debug.Log("포션 1 사용");
		}
		else
		{
			Debug.Log("포션이 없습니다");
		}
	}

	public void AddCount(int add)
	{
		_count += add;
	}
}
