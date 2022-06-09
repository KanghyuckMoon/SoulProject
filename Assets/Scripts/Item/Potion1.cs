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
}
