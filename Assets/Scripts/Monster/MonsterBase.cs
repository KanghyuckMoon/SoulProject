using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour, IMonster
{
	[SerializeField]
	private int _level = 5;
	[SerializeField]
	private GameObject _selection =	null;

	private CharacterController _characterController = null;
	public bool IsSelect 
	{
		get
		{
			return _isSelect;
		}
		set
		{
			_isSelect = value;
		}
	}

	public Transform Transform
	{
		get
		{
			return transform;
		}
		set
		{

		}
	}

	public Vector3 Position
	{
		get
		{
			return _centerPivot.position;
		}
		set
		{

		}
	}

	private bool _isSelect = false;

	[SerializeField]
	private Transform _centerPivot;
	//ĳ���� ���� �̵� ���� �ʱ갪
	private Vector3 _moveDirect = Vector3.zero;
	private Vector3 _gravityDirect = Vector3.zero;
	[SerializeField]
	private float _moveSpeed = 0f;
	[SerializeField]
	private float _gravitySpeed = 0f;
	//���� ȸ���ӵ�
	[SerializeField]
	private float _rotateSpeed = 100.0f;
	[SerializeField]
	private float _bodyRotateSpeed = 50.0f;
	[Range(0.01f, 1f)]
	[Tooltip("���� ���� ��")]
	public float velocityChangeSpeed = 0.01f;
	//ĳ���� ���� �̵� �ӵ� �ʱ갪 
	private Vector3 currentVelocitySpeed = Vector3.zero;

	private void Start()
	{
		_characterController = GetComponent<CharacterController>();
	}

	public void Update()
	{
		if(!IsSelect)
		{
			MonsterAI();
		}
		else
		{

		}
		BodyDirectChange();
	}

	public bool CheckCapture(int level)
	{
		if (_level <= level)
		{
			Debug.Log("���� ����");
			return true;
		}
		else
		{
			Debug.Log("���� �Ұ���");
			return false;
		}
	}

	public bool KeyESkill()
	{
		Debug.Log("��ųE");
		if (IsSelect)
		{
			return false;
		}
		return true;
	}

	public bool KeyRSkill()
	{
		Debug.Log("��ųR");
		if (IsSelect)
		{
			return false;
		}
		return true;
	}

	public void MonsterAI()
	{
		
	}

	public bool MouseLButtonSkill()
	{
		Debug.Log("��ųMLB");
		if (IsSelect)
		{
			return false;
		}
		return true;
	}

	public bool MouseRButtonSkill()
	{
		Debug.Log("��ųMRB");
		if (IsSelect)
		{
			return false;
		}
		return true;
	}

	public void SelectMonster()
	{
		_selection.gameObject.SetActive(true);
		IsSelect = true;

	}

	public void UnSelectMonster()
	{
		_selection.gameObject.SetActive(false);
		IsSelect = false;
	}

	public bool MonsterMove(Vector3 targetVector)
	{
		if (IsSelect)
		{

			float inputX = Input.GetAxis("Horizontal");
			float inputY = Input.GetAxis("Vertical");

			if (inputY >= 0)
			{
				_moveDirect = Vector3.RotateTowards(_moveDirect, targetVector, _rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000.0f);
				_moveDirect = _moveDirect.normalized;
			}

			Vector3 amount = (targetVector * _moveSpeed * Time.deltaTime) + (_gravityDirect * Time.deltaTime);

			_characterController.Move(amount);

			return false;
		}
		return true;
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
			currentVelocitySpeed = Vector3.Lerp(currentVelocitySpeed, retVelocity, velocityChangeSpeed * Time.fixedDeltaTime);
		}

		return currentVelocitySpeed.magnitude;
	}

}
