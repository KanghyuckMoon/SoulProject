using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
	[SerializeField]
	private List<Object> _Iinitializes;


	private void Awake()
	{
		int count = _Iinitializes.Count;
		for (int i = 0; i < count; i++)
		{
			(_Iinitializes[i] as IInit).Init();
		}
	}
}
