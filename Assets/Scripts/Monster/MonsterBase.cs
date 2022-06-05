using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour, IMonster
{
	[SerializeField]
	private int _level = 5;
	[SerializeField]
	private GameObject _selection =	null;

	public bool IsSelect 
	{
		get
		{
			return _isSelect;
		}
		set
		{
			_isSelect = value;
		}
	}

	public Transform Transform
	{
		get
		{
			return transform;
		}
		set
		{

		}
	}

	private bool _isSelect = false;

	public void Update()
	{
		if(!IsSelect)
		{
			MonsterAI();
		}
	}

	public bool CheckCapture(int level)
	{
		if (_level <= level)
		{
			Debug.Log("ºùÀÇ °¡´É");
			return true;
		}
		else
		{
			Debug.Log("ºùÀÇ ºÒ°¡´É");
			return false;
		}
	}

	public bool KeyESkill()
	{
		if (IsSelect)
		{
			return false;
		}
		return true;
	}

	public bool KeyRSkill()
	{
		if (IsSelect)
		{
			return false;
		}
		return true;
	}

	public void MonsterAI()
	{
		
	}

	public bool MouseLButtonSkill()
	{
		if (IsSelect)
		{
			return false;
		}
		return true;
	}

	public bool MouseRButtonSkill()
	{
		if (IsSelect)
		{
			return false;
		}
		return true;
	}

	public void SelectMonster()
	{
		_selection.gameObject.SetActive(true);
		IsSelect = true;

	}

	public void UnSelectMonster()
	{
		_selection.gameObject.SetActive(false);
		IsSelect = false;
	}

	public bool MonsterMove(Vector3 targetVector)
	{
		if (IsSelect)
		{
			return false;
		}
		return true;
	}
}
