using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class PlayerMove : MonoBehaviour
{
	[SerializeField]
	private float _moveSpeed = 0f; //이동속도
	[SerializeField]
	private float _gravitySpeed = 0f; //중력 받는 속도
	[SerializeField]
	private float _rotateSpeed = 100.0f; //방향 회전속도
	[SerializeField]
	private float _bodyRotateSpeed = 50.0f; //몸통 회전 속도
	[Range(0.01f, 1f)]
	public float _velocityChangeSpeed = 0.01f; //가변 증가값

	//속성
	private Vector3 currentVelocitySpeed = Vector3.zero; //이동속도 초깃값
	private Vector3 _moveDirect = Vector3.zero; //캐릭터 현재 이동방향 초깃값
	private Vector3 _gravityDirect = Vector3.zero; //현재 중력 크기 초깃값
	private Player _player; //플레이어

	public void Start()
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
			MonsterMove();
		}
		else
		{
			Move();
			SetGravity();
			BodyDirectChange();
		}
		
	}


	//빙의 전
	/// <summary>
	/// 이동함수
	/// </summary>
	private void Move()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		Vector3 forward = _player.MainCamera.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		Vector3 right = new Vector3(forward.z, 0, -forward.x);

		//캐릭터 이동방향
		Vector3 targetDirect = inputX * right + inputY * forward;

		_moveDirect = Vector3.RotateTowards(_moveDirect, targetDirect, _rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000.0f);
		_moveDirect = _moveDirect.normalized;

		Vector3 amount = (targetDirect * _moveSpeed * Time.deltaTime) + (_gravityDirect * Time.deltaTime);

		_player.CharacterController.Move(amount);
	}

	/// <summary>
	/// 몸통 돌리기
	/// </summary>
	private void BodyDirectChange()
	{
		if (GetVelocitySpd() > 0.0f)
		{
			transform.forward = Vector3.Lerp(transform.forward, _moveDirect, _bodyRotateSpeed * Time.deltaTime);
		}
	}

	/// <summary>
	/// 속도 반환
	/// </summary>
	private float GetVelocitySpd()
	{
		if (_player.CharacterController.velocity == Vector3.zero)
		{
			currentVelocitySpeed = Vector3.zero;
		}
		else
		{
			Vector3 retVelocity = _player.CharacterController.velocity;
			retVelocity.y = 0;
			currentVelocitySpeed = Vector3.Lerp(currentVelocitySpeed, retVelocity, _velocityChangeSpeed * Time.fixedDeltaTime);
		}

		return currentVelocitySpeed.magnitude;
	}

	/// <summary>
	/// 중력 설정
	/// </summary>
	private void SetGravity()
	{
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit raycastHit;

		if (Input.GetKey(KeyCode.Space))
		{
			_gravityDirect.y = _gravitySpeed;
		}
		else if (Physics.Raycast(ray, out raycastHit, 1.5f))
		{
			_gravityDirect.y = 0;
		}
		else
		{
			_gravityDirect.y = -_gravitySpeed;
		}
	}

	
	//빙의 후

	/// <summary>
	/// 빙의 몬스터 체력 증가
	/// </summary>
	/// <param name="hp"></param>
	public void AddMonsterHP(int hp)
	{
		if(_player.CaptureMonster != null)
		{
			_player.CaptureMonster.HP += hp;
		}
	}

	/// <summary>
	/// 몬스터를 이동시킴
	/// </summary>
	private void MonsterMove()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		transform.position = _player.CaptureMonster.Position;

		Vector3 forward = _player.MainCamera.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		Vector3 right = new Vector3(forward.z, 0, -forward.x);

		//캐릭터 이동방향
		Vector3 targetDirect = inputX * right + inputY * forward;

		_moveDirect = Vector3.RotateTowards(_moveDirect, targetDirect, _rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000.0f);
		_moveDirect = _moveDirect.normalized;

		_player.CaptureMonster.MonsterMove(_moveDirect, _player.IsTarggeting);
	}
	

}
