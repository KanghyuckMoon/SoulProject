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
	public string Name
	{
		get;
	}
	public string Description
	{
		get;
	}

	void UseItem(PlayerMove player);

	void AddCount(int add);
}
