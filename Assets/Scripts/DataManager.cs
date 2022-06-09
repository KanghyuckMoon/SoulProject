using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
	private static PlayerData _playerData; //�÷��̾� ������
	private static InventoryData _inventoryData; //�κ��丮 ������
	private static MonsterData _monsterData; //���� ���͸� ������ ������

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
	private int _level = 1; //��ȥ�� ����
	private float _moveSpeed = 5.0f; //��ȥ�� �̵��ӵ�
	
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
	private int _maxSize = 3; //�κ��丮 ũ��
	public List<IItem> _items = new List<IItem>(); //�κ��丮�� �� �����۵�

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
	private string _monsterName = ""; //������ �̸�
	private int _level = 1; //������ ����
	private int _hp = 10; //������ ü��
	private int _atk = 1; //������ ���ݷ�
	private float _moveSpeed = 1.0f; //������ �̵��ӵ�

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