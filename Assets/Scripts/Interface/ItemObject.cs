using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
	[SerializeField]
	protected int _count;

	public IItem Item
	{
		get
		{
			return _item;
		}
	}

	protected IItem _item;
}
