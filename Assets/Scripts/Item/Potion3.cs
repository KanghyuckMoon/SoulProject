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
			return "세번째 포션";
		}
	}
	private int _count;

	public void UseItem(PlayerMove player)
	{
		if(_count > 0)
		{
			--_count;
			Debug.Log("포션 3 사용");
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
