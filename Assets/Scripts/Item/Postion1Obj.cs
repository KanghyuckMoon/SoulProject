using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postion1Obj : ItemObject 
{
	private void Start()
	{
		_item = new Potion1()
		{
			Count = _count,
		};
	}
}
