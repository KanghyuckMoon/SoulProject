using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour, IAttack
{
	public bool IsPlayer 
	{
		get
		{
			return _isPlayer;
		}
		set
		{
			_isPlayer = value;
		}
	}
	public GameObject Effect 
	{ 
		get
		{
			return _effect;
		}
		set
		{
			_effect = value;
		}
	}
	public int Damage 
	{ 
		get
		{
			return _damage;
		}

		set
		{
			_damage = value;
		}
	}

	private bool _isPlayer = false; //�÷��̾��� ��������
	private GameObject _effect = null; //����Ʈ
	private int _damage = 10; //������
}
