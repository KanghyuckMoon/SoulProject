using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction
{
	public Transform Transform
	{
		get;
	}

	/// <summary>
	/// 상호작용 이름
	/// </summary>
	public string InteractionName
	{
		get;
	}

	/// <summary>
	/// 상호작용 동작의 이름
	/// </summary>
	public string InteractionActionName
	{
		get;
	}

	/// <summary>
	/// 상호작용
	/// </summary>
	/// <param name="player"></param>
	void Interaction(Player player);
}
