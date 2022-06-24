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

	public GameObject Attacker
	{
		get;
		set;
	}

	public GameObject Effect
	{
		get;
		set;
	}

	public int OriginDamage
	{
		get;
		set;
	}

	public int AddDamage
	{
		get;
		set;
	}

	public int Damage
	{
		get;
	}
}
