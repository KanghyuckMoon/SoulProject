using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour, IMonster
{
	//���� ����
	public enum MonsterState
	{
		None,
		Idle,
		Move,
		Wait,
		GoTarget,
		Attack,
		Damage,
		Die,
	}

	//������Ƽ
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

	public int HP
	{
		get
		{
			return _hp;
		}
		set
		{
			_hp = value;
		}
	}

	public bool IsCapture
	{
		get
		{
			return _isCapture;
		}
		set
		{
			_isCapture = value;
		}
	}

	//�ν����Ϳ��� Ȯ���� �� �ִ� �Ӽ�
	[SerializeField]
	private MonsterState _monsterState = MonsterState.None; //���� ����
	[SerializeField]
	private int _level = 5; //�ʱ� ����
	[SerializeField]
	private GameObject _selection = null; //���õ� �� ų ���̴� ������Ʈ
	[SerializeField]
	private Transform _centerPivot; //�߽��� Ʈ������
	[SerializeField]
	private float _moveSpeed = 0f; //�̵��ӵ�
	[SerializeField]
	private float _gravitySpeed = 0f; //�߷¼ӵ�
	[SerializeField]
	private float _rotateSpeed = 100.0f; //���� ȸ���ӵ�
	[SerializeField]
	private float _bodyRotateSpeed = 50.0f; //���� ȸ���ӵ�
	[Range(0.01f, 1f)]
	[SerializeField]
	private float velocityChangeSpeed = 0.01f; //���� ������
	[SerializeField]
	private int _hp = 100; //ü��

	//�����ϴ� �Ӽ�
	private CharacterController _characterController = null;
	private Animator _animator = null;

	//�Ӽ�
	private bool _isSelect = false; //���õǾ�����
	private bool _isCapture = false; //���� �Ǿ�����
	private Vector3 _moveDirect = Vector3.zero; //�̵�����
	private Vector3 _gravityDirect = Vector3.zero; //�߷� ����
	private Vector3 currentVelocitySpeed = Vector3.zero; //ĳ���� ���� �̵� �ӵ�



	private void Start()
	{
		_characterController = GetComponent<CharacterController>();
		_animator = GetComponent<Animator>();
	}

	public void Update()
	{
		if(!_isCapture)
		{
			MonsterAI();
		}
		else
		{

		}
		BodyDirectChange();
		SetGravity();
		SetAnimation();
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

	public virtual bool KeyESkill()
	{
		Debug.Log("��ųE");
		if (IsSelect)
		{
			_animator.SetTrigger("IsAttack");
			return false;
		}
		return true;
	}

	public virtual bool KeyRSkill()
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

	public virtual bool MouseLButtonSkill()
	{
		Debug.Log("��ųMLB");
		if (IsSelect)
		{
			return false;
		}
		return true;
	}

	public virtual bool MouseRButtonSkill()
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
	/// �ִϸ��̼� ����
	/// </summary>
	private void SetAnimation()
	{

	}

	/// <summary>
	/// �߷� ����
	/// </summary>
	private void SetGravity()
	{
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit raycastHit;

		if (Physics.Raycast(ray, out raycastHit, 1.5f))
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
			_animator.SetBool("IsWalk", false);
		}
		else
		{
			Vector3 retVelocity = _characterController.velocity;
			retVelocity.y = 0;
			currentVelocitySpeed = Vector3.Lerp(currentVelocitySpeed, retVelocity, velocityChangeSpeed * Time.fixedDeltaTime);
			_animator.SetBool("IsWalk", true);
		}

		return currentVelocitySpeed.magnitude;
	}

	/// <summary>
	/// ���� �浹
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("ATK"))
		{
			var iAttack = other.GetComponent<IAttack>();
			if(iAttack.IsPlayer != _isSelect)
			{
				//���ݹ���
				Damaged(iAttack);
			}
		}
	}

	/// <summary>
	/// ���ݹ޾��� �� �Լ�
	/// </summary>
	/// <param name="iAttack"></param>
	private void Damaged(IAttack iAttack)
	{
		_hp -= iAttack.Damage;
		Instantiate(iAttack.Effect, transform.position, Quaternion.identity);
		if (_hp > 0)
		{
			_monsterState = MonsterState.Damage;
		}
		else
		{
			_monsterState = MonsterState.Die;
		}
	}
}
