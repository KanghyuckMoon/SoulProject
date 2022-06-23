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

	public int SPD
	{
		get
		{
			return _speed;
		}
		set
		{
			_speed = value;
		}
	}

	public int DEF
	{
		get
		{
			return _defense;
		}
		set
		{
			_defense = value;
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
	private int _speed = 30;
	[SerializeField]
	private int _defense = 30;
	[SerializeField]
	private int _level = 1;
	[SerializeField]
	private int _exp = 0;
	[SerializeField]
	private MoneySO _moneySO = null;

	private Player _player;

	public void Start()
	{
		_player = GetComponent<Player>();
	}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.G))
		{
			Die();
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

		if(_player.CaptureMonster != null)
		{
			_player.CaptureMonster.AddEXP(exp);
		}
	}

	/// <summary>
	/// 돈 증가
	/// </summary>
	/// <param name="add"></param>
	public void AddMoney(int add)
	{
		_moneySO.AddMoney(add);
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
		_player.BattleUICanvas?.SettingSoulInfo(this);
		if (_hp <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		_player.GameOverUIManager.Setting();
		gameObject.SetActive(false);
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
