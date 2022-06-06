using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IAttack
{
	public bool IsPlayer
	{
		get;
		set;
	}

	public GameObject Effect
	{
		get;
		set;
	}

	public int Damage
	{
		get;
		set;
	}
}
