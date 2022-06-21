using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class PlayerCapture : MonoBehaviour
{
	private Player _player;

	private void Start()
	{
		_player = GetComponent<Player>();
	}

	public void Update()
	{
		if(_player.IsCantAnything)
		{
			return;
		}

		if(_player.IsCapture)
		{
			if(_player.CaptureMonster.HP <= 0)
			{
				OutCaptureMonster();
			}
			_player.BattleUICanvas?.SettingSkillUI(_player.CaptureMonster);
			SkillE();
			SkillR();
			SkillMLB();
			SkillMRB();

			if (Input.GetKeyDown(KeyCode.Q))
			{
				OutCaptureMonster();
			}
		}
		else
		{
			_player.BattleUICanvas?.NoneSettingSkillUI();
			Capture();
		}
	}

	/// <summary>
	/// 빙의 시도
	/// </summary>
	private void Capture()
	{
		Vector3 startPoint = transform.position;
		Vector3 forward = _player.MainCamera.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		Ray ray = new Ray(startPoint, forward);
		Debug.DrawRay(startPoint, forward * 100, Color.red);

		RaycastHit raycastHit;

		if (Physics.Raycast(ray, out raycastHit, 100))
		{
			var monster = raycastHit.collider.gameObject.GetComponent<IMonster>();
			if (_player.SelectMonster != null & monster != _player.SelectMonster)
			{
				_player.SelectMonster.UnSelectMonster();
			}
			_player.SelectMonster = monster;
			_player.SelectMonster?.SelectMonster();

			if (Input.GetMouseButtonDown(0))
			{
				if (_player.SelectMonster != null)
				{
					if (_player.SelectMonster.CheckCapture(1))
					{
						_player.IsCantAnything = true;
						_player.CaptureMonster = _player.SelectMonster;
						_player.CaptureMonster.GameObject.layer = LayerMask.NameToLayer("Player");
						_player.CaptureMonster.Capture();
						_player.CharacterController.enabled = false;
						_player.IsCapture = true;
						HOTween.Init(true, true, true);
						HOTween.To(transform, 0.5f, new TweenParms().Prop("position", _player.CaptureMonster.Position).OnComplete(() => _player.IsCantAnything = false));
					}
				}
			}
		}
		else
		{
			_player.SelectMonster?.UnSelectMonster();
			_player.SelectMonster = null;
		}
	}

	/// <summary>
	/// 빙의해제
	/// </summary>
	public void OutCaptureMonster()
	{
		_player.CaptureMonster.GameObject.layer = LayerMask.NameToLayer("Monster"); ;
		_player.IsCapture = false;
		_player.CaptureMonster.UnCapture();
		_player.CaptureMonster = null;
		_player.SelectMonster = null;
		_player.CharacterController.enabled = true;
	}

	/// <summary>
	/// E 스킬
	/// </summary>
	private void SkillE()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			_player.CaptureMonster.KeyESkill();
		}
	}

	/// <summary>
	/// R 스킬
	/// </summary>
	private void SkillR()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			_player.CaptureMonster.KeyRSkill();
		}
	}

	/// <summary>
	/// 마우스 왼쪽 버튼 스킬
	/// </summary>
	private void SkillMLB()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_player.CaptureMonster.MouseLButtonSkill();
		}
	}

	/// <summary>
	/// 마우스 오른쪽 버튼 스킬
	/// </summary>
	private void SkillMRB()
	{
		if (Input.GetMouseButtonDown(1))
		{
			_player.CaptureMonster.MouseRButtonSkill();
		}
	}
}
