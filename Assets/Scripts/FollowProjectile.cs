using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowProjectile : MonoBehaviour
{
	public Transform _targetTransform;
	public Vector3 _currentDirection = Vector3.zero;
	public float _moveSpeed = 2.0f;
	private bool _isPlayer;

	public void Initialized(bool isPlayer)
	{
		_isPlayer = isPlayer;
	}

	private void Update()
	{
		Move();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Monster"))
		{
			if (_isPlayer != other.gameObject.GetComponent<IMonster>().IsCapture)
			{
				_targetTransform = other.transform;
			}
		}
	}

	/// <summary>
	/// 투사체의 이동함수
	/// </summary>
	private void Move()
	{
		//목표가 있을 경우
		if(_targetTransform != null)
		{
			Vector3 driection =  _targetTransform.position - transform.position; //목표를 향하는 벡터
			transform.Translate(driection * _moveSpeed * Time.deltaTime); //목표를 향해 이동

			//float angle = Mathf.Atan2(driection.z, driection.x) * Mathf.Rad2Deg; //위에서 바라보았을 때 각도
			//Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.up); //y축을 기준으로 회전
			//Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, _moveSpeed * Time.deltaTime); //현재 각도에서 서서히 변경
			//transform.rotation = rotation; //현재 각도를 서서히 변경한 각도로 변경
		}
	}
}
