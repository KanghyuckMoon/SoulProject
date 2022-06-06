using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class PlayerMove : MonoBehaviour
{
	//인스펙터에서 설정할 수 있는 변수들
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

	//참조하는 변수
	private Camera _mainCamera = null; //메인 카메라
	private IMonster _selectMonster = null; //마우스로 선택한 몬스터
	private IMonster _captureMonster = null; //빙의한 몬스터
	private Collider _collider = null; //피격판정
	private CharacterController _characterController; //캐릭터 컨트롤러

	//속성
	private Vector3 currentVelocitySpeed = Vector3.zero; //이동속도 초깃값
	private bool _isCapture = false; //빙의중인 상태
	private bool _isCantAnything = false; //아무 것도 할 수 없는 상태
	private Vector3 _moveDirect = Vector3.zero; //캐릭터 현재 이동방향 초깃값
	private Vector3 _gravityDirect = Vector3.zero; //현재 중력 크기 초깃값
	private Tweener _tweener = null; //트위너

	private void Start()
	{
		//카메라 캐싱
		_mainCamera = Camera.main;
		_collider = GetComponent<Collider>();
		_characterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		if(_isCantAnything)
		{
			return;
		}

		if(_isCapture)
		{
			MonsterMove();
			SkillE();
			SkillR();
			SkillMLB();
			SkillMRB();
			if(Input.GetKeyDown(KeyCode.Q))
			{
				OutCaptureMonster();
			}
		}
		else
		{
			Move();
			SetGravity();
			TryCapture();
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
					if(_selectMonster.CheckCapture(1))
					{
						_isCantAnything = true;
						_captureMonster = _selectMonster;
						_captureMonster.Capture();
						_collider.enabled = false;
						_isCapture = true;
						HOTween.Init(true, true, true);
						HOTween.To(transform, 0.5f, new TweenParms().Prop("position", _captureMonster.Position).OnComplete(() => _isCantAnything = false));
					}
				}
			}
		}
		else
		{
			_selectMonster?.UnSelectMonster();
			_selectMonster = null;
		}
	}

	//빙의 후

	/// <summary>
	/// 몬스터를 이동시킴
	/// </summary>
	private void MonsterMove()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		transform.position = _captureMonster.Position;

		Vector3 forward = _mainCamera.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		Vector3 right = new Vector3(forward.z, 0, -forward.x);

		//캐릭터 이동방향
		Vector3 targetDirect = inputX * right + inputY * forward;

		if (inputY >= 0)
		{
			_moveDirect = Vector3.RotateTowards(_moveDirect, targetDirect, _rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000.0f);
			_moveDirect = _moveDirect.normalized;
		}

		_captureMonster.MonsterMove(targetDirect);
	}

	/// <summary>
	/// E 스킬
	/// </summary>
	private void SkillE()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			_captureMonster.KeyESkill();
		}
	}

	/// <summary>
	/// R 스킬
	/// </summary>
	private void SkillR()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			_captureMonster.KeyRSkill();
		}
	}

	/// <summary>
	/// 마우스 왼쪽 버튼 스킬
	/// </summary>
	private void SkillMLB()
	{
		if(Input.GetMouseButtonDown(0))
		{
			_captureMonster.MouseLButtonSkill();
		}
	}

	/// <summary>
	/// 마우스 오른쪽 버튼 스킬
	/// </summary>
	private void SkillMRB()
	{
		if (Input.GetMouseButtonDown(1))
		{
			_captureMonster.MouseRButtonSkill();
		}
	}

	/// <summary>
	/// 빙의해제
	/// </summary>
	private void OutCaptureMonster()
	{
		_captureMonster.UnCapture();
		_captureMonster = null;
		_selectMonster = null;
		_isCapture = false;
		_collider.enabled = true;
	}
}
