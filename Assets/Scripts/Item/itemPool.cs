using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonLibrary.Pool;

public class itemPool : PoolManager
{
	public void AddQueue<T>()
	{
		Queue<T> value = new Queue<T>();
		if (!queueDictionary.TryGetValue(typeof(T).Name, out object _))
		{
			queueDictionary.Add(typeof(T).Name, value);
		}
	}
}
