using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private List<IItem> items = new List<IItem>();

	private void Start()
	{
		Potion1 potion1 = new Potion1();
		potion1.Count = 3;
		Potion2 potion2 = new Potion2();
		potion2.Count = 3;
		Potion3 potion3 = new Potion3();
		potion3.Count = 3;
		items.Add(potion1);
		items.Add(potion2);
		items.Add(potion3);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			items[0].UseItem();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			items[1].UseItem();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			items[2].UseItem();
		}
	}

}
