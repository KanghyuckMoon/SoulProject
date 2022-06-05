using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMonster
{
	/// <summary>
	/// 빙의가 가능한지 체크
	/// </summary>
	/// <param name="level">레벨에 따라 빙의 가능한지 체크</param>
	void CheckCapture(int level);

	/// <summary>
	/// 몬스터가 선택될 때
	/// </summary>
	void SelectMonster();

	/// <summary>
	/// 몬스터가 선택이 취소될 때
	/// </summary>
	void UnSelectMonster();

	/// <summary>
	/// 왼쪽 마우스 버튼 스킬
	/// </summary>
	void MouseLButtonSkill();

	/// <summary>
	/// 오른쪽 마우스 버튼 스킬
	/// </summary>
	void MouseRButtonSkill();

	/// <summary>
	/// E키 스킬
	/// </summary>
	void KeyESkill();

	/// <summary>
	/// R키 스킬
	/// </summary>
	void KeyRSkill();

	/// <summary>
	/// 몬스터 AI
	/// </summary>
	void MonsterAI();
}
