using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour, IMonster
{
	//몬스터 상태
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

	//프로퍼티
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

	//인스펙터에서 확인할 수 있는 속성
	[SerializeField]
	private MonsterState _monsterState = MonsterState.None; //몬스터 상태
	[SerializeField]
	private int _level = 5; //초기 레벨
	[SerializeField]
	private GameObject _selection = null; //선택될 때 킬 쉐이더 오브젝트
	[SerializeField]
	private Transform _centerPivot; //중심점 트랜스폼
	[SerializeField]
	private float _moveSpeed = 0f; //이동속도
	[SerializeField]
	private float _gravitySpeed = 0f; //중력속도
	[SerializeField]
	private float _rotateSpeed = 100.0f; //방향 회전속도
	[SerializeField]
	private float _bodyRotateSpeed = 50.0f; //몸통 회전속도
	[Range(0.01f, 1f)]
	[SerializeField]
	private float velocityChangeSpeed = 0.01f; //가변 증가값
	[SerializeField]
	private int _hp = 100; //체력

	//참조하는 속성
	private CharacterController _characterController = null;
	private Animator _animator = null;

	//속성
	private bool _isSelect = false; //선택되었는지
	private bool _isCapture = false; //빙의 되었는지
	private Vector3 _moveDirect = Vector3.zero; //이동방향
	private Vector3 _gravityDirect = Vector3.zero; //중력 벡터
	private Vector3 currentVelocitySpeed = Vector3.zero; //캐릭터 현재 이동 속도



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
			Debug.Log("빙의 가능");
			return true;
		}
		else
		{
			Debug.Log("빙의 불가능");
			return false;
		}
	}

	public virtual bool KeyESkill()
	{
		Debug.Log("스킬E");
		if (IsSelect)
		{
			_animator.SetTrigger("IsAttack");
			return false;
		}
		return true;
	}

	public virtual bool KeyRSkill()
	{
		Debug.Log("스킬R");
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
		Debug.Log("스킬MLB");
		if (IsSelect)
		{
			return false;
		}
		return true;
	}

	public virtual bool MouseRButtonSkill()
	{
		Debug.Log("스킬MRB");
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
	/// 애니메이션 설정
	/// </summary>
	private void SetAnimation()
	{

	}

	/// <summary>
	/// 중력 설정
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
	/// 공격 충돌
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("ATK"))
		{
			var iAttack = other.GetComponent<IAttack>();
			if(iAttack.IsPlayer != _isSelect)
			{
				//공격받음
				Damaged(iAttack);
			}
		}
	}

	/// <summary>
	/// 공격받았을 때 함수
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
