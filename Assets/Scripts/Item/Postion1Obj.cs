using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postion1Obj : ItemObject, IInteraction
{
	public string InteractionName
	{
		get
		{
			return "����1";
		}
	}

	public string InteractionActionName
	{
		get
		{
			return "�ݱ�";
		}
	}

	public Transform Transform
	{
		get
		{
			return transform;
		}
	}

	public void Interaction(PlayerMove player)
	{
		player.AddItem(_item);
	}
}
