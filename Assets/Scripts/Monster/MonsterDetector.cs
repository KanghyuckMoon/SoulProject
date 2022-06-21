using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetector : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			gameObject.SendMessageUpwards("OnCheckTarget", other.gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}

}
