using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	//이동 속도
	[SerializeField]
	private float _moveSpeed = 0f;
	[SerializeField]
	private float _gravitySpeed = 0f;
	//방향 회전속도
	[SerializeField]
	private float _rotateSpeed = 100.0f;
	[SerializeField]
	private float _bodyRotateSpeed = 50.0f;

	private Camera _mainCamera = null;

	//캐릭터 현재 이동 방향 초깃값
	private Vector3 _moveDirect = Vector3.zero;
	private Vector3 _gravityDirect = Vector3.zero;


	[Range(0.01f, 1f)]
	[Tooltip("가변 증가 값")]
	public float velocityChangeSpeed = 0.01f;
	//캐릭터 현재 이동 속도 초깃값 
	private Vector3 currentVelocitySpeed = Vector3.zero;

	private CharacterController _characterController;

	private IMonster _selectMonster = null;

	private void Start()
	{
		//카메라 캐싱
		_mainCamera = Camera.main;
		_characterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		Move();
		SetGravity();
		TryCapture();
		BodyDirectChange();
	}

	/// <summary>
	/// 이동함수
	/// </summary>
	private void Move()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		Vector3 forward = _mainCamera.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		Vector3 right = new Vector3(forward.z, 0, -forward.x);

		//캐릭터 이동방향
		Vector3 targetDirect = inputX * right + inputY * forward;

		if(inputY >= 0)
		{
			_moveDirect = Vector3.RotateTowards(_moveDirect, targetDirect, _rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000.0f);
			_moveDirect = _moveDirect.normalized;
		}

		Vector3 amount = (targetDirect * _moveSpeed * Time.deltaTime) + (_gravityDirect * Time.deltaTime);

		_characterController.Move(amount);
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
		if (_characterController.velocity == Vector3.zero)
		{
			currentVelocitySpeed = Vector3.zero;
		}
		else
		{
			Vector3 retVelocity = _characterController.velocity;
			retVelocity.y = 0;
			currentVelocitySpeed = Vector3.Lerp(currentVelocitySpeed, retVelocity, velocityChangeSpeed * Time.fixedDeltaTime);
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

	/// <summary>
	/// 빙의 시도
	/// </summary>
	private void TryCapture()
	{
		Vector3 startPoint = transform.position;
		Vector3 forward = _mainCamera.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		Ray ray = new Ray(startPoint, forward);
		Debug.DrawRay(startPoint, forward * 100, Color.red);

		RaycastHit raycastHit;

		if (Physics.Raycast(ray, out raycastHit, 100))
		{
			_selectMonster = raycastHit.collider.gameObject.GetComponent<IMonster>();
			_selectMonster?.SelectMonster();
			
			if (Input.GetMouseButtonDown(0))
			{
				if (_selectMonster != null)
				{
					_selectMonster.CheckCapture(1);
				}
			}
		}
		else
		{
			_selectMonster?.UnSelectMonster();
			_selectMonster = null;
		}
	}

}
