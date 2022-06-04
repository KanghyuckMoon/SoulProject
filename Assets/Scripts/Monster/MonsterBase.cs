using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour, IMonster
{
	[SerializeField]
	private int _level = 5;
	[SerializeField]
	private Material _defaultMaterial;
	[SerializeField]
	private Material _selectMaterial;
	private MeshRenderer _meshRenderer;

	private void Start()
	{
		_meshRenderer = GetComponent<MeshRenderer>();
	}

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


	public void SelectMonster()
	{
		Debug.Log("����");
		_meshRenderer.material = _selectMaterial;

	}

	public void UnSelectMonster()
	{
		Debug.Log("���� ���");
		_meshRenderer.material = _defaultMaterial;
	}
}
