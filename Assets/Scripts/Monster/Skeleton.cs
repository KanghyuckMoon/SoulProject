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
		_description = "뼈로 이루어진 몬스터, 자아가 있을거라고 생각하진 않지만 무시하기에는 날카로운 검을 지니고 있다";
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
