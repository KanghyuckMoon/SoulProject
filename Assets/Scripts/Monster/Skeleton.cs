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
		_name = "½ºÄÌ·¹Åæ";
		_canSkillMLB = true;
		_canSkillMRB = true;
		_canSkillE = true;
		_canSkillR = true;
	}

	public override bool KeyESkill()
	{
		if (CheckCoolTimeE())
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.E;
			_coolTimeE = 0;
			return true;
		}
		return false;
	}

	public override bool KeyRSkill()
	{
		if (CheckCoolTimeR())
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.R;
			_coolTimeR = 0;
			return true;
		}
		return false;
	}

	public override bool MouseLButtonSkill()
	{
		if (CheckCoolTimeMLB())
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.MLB;
			_coolTimeMLB = 0;
			return true;
		}
		return false;
	}

	public override bool MouseRButtonSkill()
	{
		if (CheckCoolTimeMRB())
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.MRB;
			_coolTimeMRB = 0;
			return true;
		}
		return false;
	}
}
