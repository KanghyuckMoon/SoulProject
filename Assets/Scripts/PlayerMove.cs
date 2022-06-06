using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class PlayerMove : MonoBehaviour
{
	//�ν����Ϳ��� ������ �� �ִ� ������
	[SerializeField]
	private float _moveSpeed = 0f; //�̵��ӵ�
	[SerializeField]
	private float _gravitySpeed = 0f; //�߷� �޴� �ӵ�
	[SerializeField]
	private float _rotateSpeed = 100.0f; //���� ȸ���ӵ�
	[SerializeField]
	private float _bodyRotateSpeed = 50.0f; //���� ȸ�� �ӵ�
	[Range(0.01f, 1f)]
	public float _velocityChangeSpeed = 0.01f; //���� ������

	//�����ϴ� ����
	private Camera _mainCamera = null; //���� ī�޶�
	private IMonster _selectMonster = null; //���콺�� ������ ����
	private IMonster _captureMonster = null; //������ ����
	private Collider _collider = null; //�ǰ�����
	private CharacterController _characterController; //ĳ���� ��Ʈ�ѷ�

	//�Ӽ�
	private Vector3 currentVelocitySpeed = Vector3.zero; //�̵��ӵ� �ʱ갪
	private bool _isCapture = false; //�������� ����
	private bool _isCantAnything = false; //�ƹ� �͵� �� �� ���� ����
	private Vector3 _moveDirect = Vector3.zero; //ĳ���� ���� �̵����� �ʱ갪
	private Vector3 _gravityDirect = Vector3.zero; //���� �߷� ũ�� �ʱ갪
	private Tweener _tweener = null; //Ʈ����

	private void Start()
	{
		//ī�޶� ĳ��
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

	//���� ��
	
	/// <summary>
	/// �̵��Լ�
	/// </summary>
	private void Move()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		Vector3 forward = _mainCamera.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		Vector3 right = new Vector3(forward.z, 0, -forward.x);

		//ĳ���� �̵�����
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
	/// ���� ������
	/// </summary>
	private void BodyDirectChange()
	{
		if (GetVelocitySpd() > 0.0f)
		{
			transform.forward = Vector3.Lerp(transform.forward, _moveDirect, _bodyRotateSpeed * Time.deltaTime);
		}
	}

	/// <summary>
	/// �ӵ� ��ȯ
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
	/// �߷� ����
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
	/// ���� �õ�
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

	//���� ��

	/// <summary>
	/// ���͸� �̵���Ŵ
	/// </summary>
	private void MonsterMove()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		transform.position = _captureMonster.Position;

		Vector3 forward = _mainCamera.transform.TransformDirection(Vector3.forward);
		forward.y = 0;
		Vector3 right = new Vector3(forward.z, 0, -forward.x);

		//ĳ���� �̵�����
		Vector3 targetDirect = inputX * right + inputY * forward;

		if (inputY >= 0)
		{
			_moveDirect = Vector3.RotateTowards(_moveDirect, targetDirect, _rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000.0f);
			_moveDirect = _moveDirect.normalized;
		}

		_captureMonster.MonsterMove(targetDirect);
	}

	/// <summary>
	/// E ��ų
	/// </summary>
	private void SkillE()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			_captureMonster.KeyESkill();
		}
	}

	/// <summary>
	/// R ��ų
	/// </summary>
	private void SkillR()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			_captureMonster.KeyRSkill();
		}
	}

	/// <summary>
	/// ���콺 ���� ��ư ��ų
	/// </summary>
	private void SkillMLB()
	{
		if(Input.GetMouseButtonDown(0))
		{
			_captureMonster.MouseLButtonSkill();
		}
	}

	/// <summary>
	/// ���콺 ������ ��ư ��ų
	/// </summary>
	private void SkillMRB()
	{
		if (Input.GetMouseButtonDown(1))
		{
			_captureMonster.MouseRButtonSkill();
		}
	}

	/// <summary>
	/// ��������
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
