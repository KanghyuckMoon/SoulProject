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
		Debug.Log("��ų�� �������� ����");
		return base.KeyRSkill();
	}

	public override bool MouseLButtonSkill()
	{
		Debug.Log("��ų�� �������� ����");
		return base.MouseLButtonSkill();
	}

	public override bool MouseRButtonSkill()
	{
		Debug.Log("��ų�� �������� ����");
		return base.MouseRButtonSkill();
	}
}
