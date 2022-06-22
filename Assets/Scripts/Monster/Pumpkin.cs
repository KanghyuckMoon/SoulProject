using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonsterBase
{
	public override void Start()
	{
		base.Start();
		_name = "펌프킨";
		_description = "호박을 머리에 뒤집어 쓴 몬스터, 날카로운 가시로 사냥감을 찔러 죽인다. 호박을 뒤집어 써 그 얼굴은 알 수 없다";
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
