using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
	private static PlayerData _playerData; //플레이어 데이터
	private static InventoryData _inventoryData; //인벤토리 데이터
	private static MonsterData _monsterData; //빙의 몬스터를 저장할 데이터

	public static PlayerData PlayerData
	{
		get
		{
			return _playerData;
		}
		set
		{
			_playerData = value;
		}
	}
	public static InventoryData InventoryData
	{
		get
		{
			return _inventoryData;
		}
		set
		{
			_inventoryData = value;
		}
	}
	public static MonsterData MonsterData
	{
		get
		{
			return _monsterData;
		}
		set
		{
			_monsterData = value;
		}
	}
}

[System.Serializable]
public class PlayerData
{
	private int _level = 1; //영혼의 레벨
	private float _moveSpeed = 5.0f; //영혼의 이동속도
	
	public int Level
	{
		get
		{
			return _level;
		}
		set
		{
			_level = value;
		}
	}
	public float MoveSpeed
	{
		get
		{
			return _moveSpeed;
		}
		set
		{
			_moveSpeed = value;
		}
	}
}

[System.Serializable]
public class InventoryData
{
	private int _maxSize = 3; //인벤토리 크기
	public List<IItem> _items = new List<IItem>(); //인벤토리에 들어간 아이템들

	public int MaxSize
	{
		get
		{
			return _maxSize;
		}
		set
		{
			_maxSize = value;
		}
	}
	public List<IItem> Items
	{
		get
		{
			return _items;
		}
		set
		{
			_items = value;
		}
	}
}

[System.Serializable]
public class MonsterData
{
	private string _monsterName = ""; //몬스터의 이름
	private int _level = 1; //몬스터의 레벨
	private int _hp = 10; //몬스터의 체력
	private int _atk = 1; //몬스터의 공격력
	private float _moveSpeed = 1.0f; //몬스터의 이동속도

	public string MonsterName
	{
		get
		{
			return _monsterName;
		}
		set
		{
			_monsterName = value;
		}
	}
	public int Level
	{
		get
		{
			return _level;
		}
		set
		{
			_level = value;
		}
	}
	public int HP
	{
		get
		{
			return _hp;
		}
		set
		{
			_hp = value;
		}
	}
	public int ATK
	{
		get
		{
			return _atk;
		}
		set
		{
			_atk = value;
		}
	}
	public float MoveSpeed
	{
		get
		{
			return _moveSpeed;
		}
		set
		{
			_moveSpeed = value;
		}
	}
}