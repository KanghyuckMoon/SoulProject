using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
	[SerializeField]
	private Canvas _optionCanvas = null;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			_optionCanvas.gameObject.SetActive(!_optionCanvas.gameObject.activeSelf);
			Time.timeScale = _optionCanvas.gameObject.activeSelf ? 0 : 1;
		}
	}
}
