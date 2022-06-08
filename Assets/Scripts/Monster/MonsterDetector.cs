using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetector : MonoBehaviour
{
	public string targetTag = "Player";

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == targetTag)
		{
			gameObject.SendMessageUpwards("OnCheckTarget", other.gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}

}
