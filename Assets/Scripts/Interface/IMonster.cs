using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMonster
{
	public bool IsSelect 
	{
		get;
		set;
	}

	public Transform Transform
	{
		get;
		set;
	}

	public Vector3 Position
	{
		get;
		set;
	}

	/// <summary>
	/// ���ǰ� �������� üũ
	/// </summary>
	/// <param name="level">������ ���� ���� �������� üũ</param>
	bool CheckCapture(int level);

	/// <summary>
	/// ���Ͱ� ���õ� ��
	/// </summary>
	void SelectMonster();

	/// <summary>
	/// ���Ͱ� ������ ��ҵ� ��
	/// </summary>
	void UnSelectMonster();
	
	/// <summary>
	/// ���Ͱ� �̵��� ��
	/// </summary>
	/// <returns></returns>
	bool MonsterMove(Vector3 targetVector);

	/// <summary>
	/// ���� ���콺 ��ư ��ų
	/// </summary>
	bool MouseLButtonSkill();

	/// <summary>
	/// ������ ���콺 ��ư ��ų
	/// </summary>
	bool MouseRButtonSkill();

	/// <summary>
	/// EŰ ��ų
	/// </summary>
	bool KeyESkill();

	/// <summary>
	/// RŰ ��ų
	/// </summary>
	bool KeyRSkill();

	/// <summary>
	/// ���� AI
	/// </summary>
	void MonsterAI();
}
