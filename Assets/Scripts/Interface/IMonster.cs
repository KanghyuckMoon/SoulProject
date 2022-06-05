using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMonster
{
	/// <summary>
	/// ���ǰ� �������� üũ
	/// </summary>
	/// <param name="level">������ ���� ���� �������� üũ</param>
	void CheckCapture(int level);

	/// <summary>
	/// ���Ͱ� ���õ� ��
	/// </summary>
	void SelectMonster();

	/// <summary>
	/// ���Ͱ� ������ ��ҵ� ��
	/// </summary>
	void UnSelectMonster();

	/// <summary>
	/// ���� ���콺 ��ư ��ų
	/// </summary>
	void MouseLButtonSkill();

	/// <summary>
	/// ������ ���콺 ��ư ��ų
	/// </summary>
	void MouseRButtonSkill();

	/// <summary>
	/// EŰ ��ų
	/// </summary>
	void KeyESkill();

	/// <summary>
	/// RŰ ��ų
	/// </summary>
	void KeyRSkill();

	/// <summary>
	/// ���� AI
	/// </summary>
	void MonsterAI();
}
