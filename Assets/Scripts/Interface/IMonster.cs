using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster
{
	public bool IsSelect 
	{
		get;
		set;
	}
	public Sprite Sprite
	{
		get;
		set;
	}
	public Transform Transform
	{
		get;
		set;
	}
	public GameObject GameObject
	{
		get;
		set;
	}
	public Vector3 Position
	{
		get;
		set;
	}
	public string Name
	{
		get;
		set;
	}
	public string Description
	{
		get;
		set;
	}
	public int HP
	{
		get;
		set;
	}
	public int MaxHP
	{
		get;
		set;
	}
	public int Level
	{
		get;
		set;
	}
	public int SPD
	{
		get;
		set;
	}
	public int DEF
	{
		get;
		set;
	}
	public int EXP
	{
		get;
		set;
	}
	public bool IsCapture
	{
		get;
		set;
	}
	public float CoolTimeMLB
	{
		get;
		set;
	}
	public float CoolTimeMRB
	{
		get;
		set;
	}
	public float CoolTimeE
	{
		get;
		set;
	}
	public float CoolTimeR
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
	/// 빙의
	/// </summary>
	void Capture();

	/// <summary>
	/// 빙의 해제
	/// </summary>
	void UnCapture();

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
	void MonsterMove(Vector3 targetVector);

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
	/// MLB 스킬을 사용할 수 있는지
	/// </summary>
	/// <returns></returns>
	bool CheckCanMLB();

	/// <summary>
	/// MRB 스킬을 사용할 수 있는지
	/// </summary>
	/// <returns></returns>
	bool CheckCanMRB();
	/// <summary>
	/// E 스킬을 사용할 수 있는지
	/// </summary>
	/// <returns></returns>
	bool CheckCanE();
	/// <summary>
	/// R 스킬을 사용할 수 있는지
	/// </summary>
	/// <returns></returns>
	bool CheckCanR();

	/// <summary>
	/// MLB 스킬의 쿨타임이 끝났는지
	/// </summary>
	/// <returns></returns>
	bool CheckCoolTimeMLB();
	/// <summary>
	/// MRB 스킬의 쿨타임이 끝났는지
	/// </summary>
	/// <returns></returns>
	bool CheckCoolTimeMRB();
	/// <summary>
	/// E 스킬의 쿨타임이 끝났는지
	/// </summary>
	/// <returns></returns>
	bool CheckCoolTimeE();
	/// <summary>
	/// R 스킬의 쿨타임이 끝났는지
	/// </summary>
	/// <returns></returns>
	bool CheckCoolTimeR();
}
