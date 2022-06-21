using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonsterBase
{
	[SerializeField]
	private GameObject _skillRProjectile;


	public override void Start()
	{
		base.Start();
		_name = "스켈레톤";
	}

	public override bool KeyESkill()
	{
		Debug.Log("스킬이 존재하지 않음");
		return base.KeyESkill();
	}

	public override bool KeyRSkill()
	{
		if (base.KeyRSkill())
		{
			FollowProjectile followProjectile = Instantiate(_skillRProjectile, transform.position, Quaternion.identity, null).GetComponent<FollowProjectile>();
			followProjectile.Initialized(IsCapture);
			return true;
		}
		else
		{
			return false;
		}
	}

	public override bool MouseLButtonSkill()
	{
		if (base.MouseLButtonSkill())
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.MLB;
			return true;
		}
		else
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.MLB;
			return false;
		}
	}

	public override bool MouseRButtonSkill()
	{
		if (base.MouseRButtonSkill())
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.MRB;
			return true;
		}
		else
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.MRB;
			return false;
		}
	}
}
