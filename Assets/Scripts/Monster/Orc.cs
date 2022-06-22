using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonsterBase
{
	public override void Start()
	{
		base.Start();
		_name = "오크";
		_description = "인간보다 커다란 체격과 근력을 지닌 몬스터로 덩치에 비해 민첩하며 초록색 피부를 이용하여 풀 속에서 사냥감이 다가오는 것을 기다린다";
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
