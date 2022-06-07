using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonsterBase
{
	public override bool KeyESkill()
	{
		if (base.KeyESkill())
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.E;
			return true;
		}
		else
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.E;
			return false;
		}
	}

	public override bool KeyRSkill()
	{
		if (base.KeyRSkill())
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.R;
			return true;
		}
		else
		{
			ChangeState(MonsterState.Attack);
			_attackState = AttackState.R;
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
