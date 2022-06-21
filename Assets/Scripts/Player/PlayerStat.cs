using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
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
	public int MaxHP
	{
		get
		{
			return _maxHp;
		}
		set
		{
			_maxHp = value;
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

	public int Exp
	{
		get
		{
			return _exp;
		}
		set
		{
			_exp = value;
		}
	}

	//인스펙터에서 설정할 수 있는 변수들
	[SerializeField]
	private int _hp = 30;
	[SerializeField]
	private int _maxHp = 30;
	[SerializeField]
	private int _level = 1;
	[SerializeField]
	private int _exp = 0;

	private Player _player;

	public void Start()
	{
		_player = GetComponent<Player>();
	}

	public void Update()
	{
		if(_player.IsCantAnything)
		{
			return;
		}

		if(HP > 0)
		{
			_player.BattleUICanvas?.SettingSoulInfo(this);
		}
		else
		{
			_player.BattleUICanvas?.NoneSettingSoulInfo();
		}

	}

	/// <summary>
	/// 체력 증가
	/// </summary>
	/// <param name="hp"></param>
	public void AddHP(int hp)
	{
		_hp += hp;
	}

	/// <summary>
	/// 경험치 증가
	/// </summary>
	/// <param name="exp"></param>
	public void AddExp(int exp)
	{
		_exp += exp;
		if (_exp > _level * 10)
		{
			LevelUP();
		}
	}

	/// <summary>
	/// 레벨업
	/// </summary>
	private void LevelUP()
	{
		++_level;
		_exp = 0;
	}


	/// <summary>
	/// 공격받음
	/// </summary>
	/// <param name="iAttack"></param>
	private void Damaged(IAttack iAttack)
	{
		_hp -= iAttack.Damage;
		Instantiate(iAttack.Effect, transform.position, Quaternion.identity);
		if (_hp <= 0)
		{
			gameObject.SetActive(false);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("ATK"))
		{
			if (_player.IsCapture)
			{
				return;
			}

			var iAttack = other.GetComponent<IAttack>();
			if (!iAttack.IsPlayer)
			{
				//공격받음
				Damaged(iAttack);
			}
		}
		else if (other.gameObject.CompareTag("Item"))
		{
		}
	}
}
