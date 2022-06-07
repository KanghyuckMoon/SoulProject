using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonsterBase
{
	[SerializeField]
	private GameObject _skillRProjectile;

	public override bool KeyESkill()
	{
		if(base.KeyESkill())
		{
			_monsterState = MonsterState.Attack;
			_attackState = AttackState.E;
			return true;
		}
		else
		{
			_monsterState = MonsterState.Attack;
			_attackState = AttackState.E;
			return false;
		}
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
		Debug.Log("스킬이 존재하지 않음");
		return base.MouseLButtonSkill();
	}

	public override bool MouseRButtonSkill()
	{
		Debug.Log("스킬이 존재하지 않음");
		return base.MouseRButtonSkill();
	}
}
