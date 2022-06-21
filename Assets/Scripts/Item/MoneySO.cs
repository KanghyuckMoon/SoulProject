using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonLibrary.DesignPattern;


[CreateAssetMenu(fileName = "MoneySO", menuName = "ScriptableObject/MoneySO")]
public class MoneySO : ScriptableObject, IObservable, IInit
{
	public int _money; //ÇÃ·¹ÀÌ¾î µ·
	private List<IObserver> _observers = new List<IObserver>(); 

	public void AddMoney(int addMoney)
	{
		_money += addMoney;
		PostNotify();
	}

	public void AddObserver(IObserver observer)
	{
		_observers.Add(observer);
	}

	public void Init()
	{
		_observers.Clear();
	}

	public void PostNotify()
	{
		foreach(var observer in _observers)
		{
			observer.GetNotify();
		}
	}
}
