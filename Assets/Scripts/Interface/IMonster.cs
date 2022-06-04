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
	void SelectMonster();
	void UnSelectMonster();
}
