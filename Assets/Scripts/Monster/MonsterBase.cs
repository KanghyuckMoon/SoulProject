using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour, IMonster
{
	[SerializeField]
	private int _level = 5;
	[SerializeField]
	private GameObject _selection =	null;

	public void CheckCapture(int level)
	{
		if (_level <= level)
		{
			Debug.Log("���� ����");
		}
		else
		{
			Debug.Log("���� �Ұ���");
		}
	}

	public void KeyESkill()
	{
		throw new System.NotImplementedException();
	}

	public void KeyRSkill()
	{
		throw new System.NotImplementedException();
	}

	public void MonsterAI()
	{
		throw new System.NotImplementedException();
	}

	public void MouseLButtonSkill()
	{
		throw new System.NotImplementedException();
	}

	public void MouseRButtonSkill()
	{
		throw new System.NotImplementedException();
	}

	public void SelectMonster()
	{
		Debug.Log("����");
		_selection.gameObject.SetActive(true);

	}

	public void UnSelectMonster()
	{
		Debug.Log("���� ���");
		_selection.gameObject.SetActive(false);
	}

}
