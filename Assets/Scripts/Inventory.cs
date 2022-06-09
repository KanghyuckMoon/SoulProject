using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private List<IItem> _items = new List<IItem>();
	private PlayerMove _playerMove = new PlayerMove();

	private void Start()
	{
		Potion1 potion1 = new Potion1();
		potion1.Count = 3;
		Potion2 potion2 = new Potion2();
		potion2.Count = 3;
		Potion3 potion3 = new Potion3();
		potion3.Count = 3;
		_items.Add(potion1);
		_items.Add(potion2);
		_items.Add(potion3);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			_items[0].UseItem(_playerMove);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			_items[1].UseItem(_playerMove);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			_items[2].UseItem(_playerMove);
		}
	}

}
