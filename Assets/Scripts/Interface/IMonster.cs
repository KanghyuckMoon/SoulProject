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
	/// 빙의가 가능한지 체크
	/// </summary>
	/// <param name="level">레벨에 따라 빙의 가능한지 체크</param>
	bool CheckCapture(int level);

	/// <summary>
	/// 몬스터가 선택될 때
	/// </summary>
	void SelectMonster();

	/// <summary>
	/// 몬스터가 선택이 취소될 때
	/// </summary>
	void UnSelectMonster();
	
	/// <summary>
	/// 몬스터가 이동할 때
	/// </summary>
	/// <returns></returns>
	bool MonsterMove(Vector3 targetVector);

	/// <summary>
	/// 왼쪽 마우스 버튼 스킬
	/// </summary>
	bool MouseLButtonSkill();

	/// <summary>
	/// 오른쪽 마우스 버튼 스킬
	/// </summary>
	bool MouseRButtonSkill();

	/// <summary>
	/// E키 스킬
	/// </summary>
	bool KeyESkill();

	/// <summary>
	/// R키 스킬
	/// </summary>
	bool KeyRSkill();

	/// <summary>
	/// 몬스터 AI
	/// </summary>
	void MonsterAI();
}
