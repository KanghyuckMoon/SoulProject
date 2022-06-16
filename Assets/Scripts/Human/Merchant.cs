using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour, IInteraction
{
	public Transform Transform
	{
		get
		{
			return _headPos;
		}
	}

	public string InteractionName
	{
		get
		{
			return "상인";
		}
	}

	public string InteractionActionName
	{
		get
		{
			return "대화";
		}
	}

	public ShopManager ShopManager
	{
		get
		{
			if(_shopManager == null)
			{
				_shopManager = FindObjectOfType<ShopManager>();
			}

			return _shopManager;
		}
	}
	public CameraMove CameraMove
	{
		get
		{
			if (_cameraMove == null)
			{
				_cameraMove = FindObjectOfType<CameraMove>();
			}

			return _cameraMove;
		}
	}

	[SerializeField]
	private Transform _headPos;
	[SerializeField]
	private ItemSetSO _itemSetSO;

	private ShopManager _shopManager;
	private CameraMove _cameraMove;

	public void Interaction(PlayerMove player)
	{
		ShopManager.Setting(player, this, _itemSetSO);
		CameraMove.AnimationCamera(_headPos.position, transform.forward);
	}

	public void EndTrade()
	{
		CameraMove.EndAnimationCamera();
	}
}
