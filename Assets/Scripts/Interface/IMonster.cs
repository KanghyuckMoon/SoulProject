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
	void SelectMonster();
	void UnSelectMonster();
}
