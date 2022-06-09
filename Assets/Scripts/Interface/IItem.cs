using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
	public int Count
	{
		get;
		set;
	}

	void UseItem(PlayerMove player);
}
