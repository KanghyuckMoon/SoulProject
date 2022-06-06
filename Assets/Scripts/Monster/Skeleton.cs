using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonsterBase
{
	public override bool KeyESkill()
	{
		if(base.KeyESkill())
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public override bool KeyRSkill()
	{
		Debug.Log("스킬이 존재하지 않음");
		return base.KeyRSkill();
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
