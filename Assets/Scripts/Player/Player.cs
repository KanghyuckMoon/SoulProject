using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class Player : MonoBehaviour
{
	//프로퍼티
	public OverWorldUIManager OverWorldUIManager
	{
		get
		{
			_overWorldUIManager ??= FindObjectOfType<OverWorldUIManager>();
			return _overWorldUIManager;
		}
	}
	public CharacterController CharacterController
	{
		get
		{
			_characterController ??= GetComponent<CharacterController>();
			return _characterController;
		}
		set
		{
			_characterController = value;
		}
	}
	public BattleUICanvas BattleUICanvas
	{
		get
		{
			_battleUICanvas ??= FindObjectOfType<BattleUICanvas>();
			return _battleUICanvas;
		}
		set
		{

		}
	}
	public ItemInventory ItemInventory
	{
		get
		{
			_itemInventory ??= FindObjectOfType<ItemInventory>();
			return _itemInventory;
		}
		set
		{
			_itemInventory = value;
		}
	}
	public NoticeManager NoticeManager
	{
		get
		{
			_noticeManager ??= FindObjectOfType<NoticeManager>();
			return _noticeManager;
		}
		set
		{
			_noticeManager = value;
		}
	}
	public IInteraction SelectObject
	{
		get
		{
			return _selectObj;
		}
		set
		{
			_selectObj = value;
		}
	}
	public IMonster SelectMonster
	{
		get
		{
			return _selectMonster;
		}
		set
		{
			_selectMonster = value;
		}
	}
	public IMonster CaptureMonster
	{
		get
		{
			return _captureMonster;
		}
		set
		{
			_captureMonster = value;
		}
	}
	public IMonster TargettingMonster
	{
		get
		{
			return _targettingMonster;
		}
		set
		{
			_targettingMonster = value;
		}
	}
	public Camera MainCamera
	{
		get
		{
			_mainCamera ??= Camera.main;
			return _mainCamera;
		}
		set
		{
			_mainCamera = value;
		}
	}
	public CameraMove MainCameraMove
	{
		get
		{
			_mainCameraMove = FindObjectOfType<CameraMove>();
			return _mainCameraMove;
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
	public bool IsCantAnything
	{
		get
		{
			return _isCantAnything;
		}
		set
		{
			_isCantAnything = value;
		}
	}
	
	private bool _isCantAnything = false; //아무 것도 할 수 없는 상태
	private bool _isCapture = false; //빙의중인 상태
	private ItemInventory _itemInventory; //아이템 인벤토리
	private NoticeManager _noticeManager; //발견 매니저
	private BattleUICanvas _battleUICanvas; //배틀UI캔버스
	private OverWorldUIManager _overWorldUIManager; //맵 UI
	private IMonster _selectMonster = null; //마우스로 선택한 몬스터
	private IMonster _captureMonster = null; //빙의한 몬스터
	private IMonster _targettingMonster; //타겟팅된 몬스터
	private IInteraction _selectObj; //선택된 오브젝트
	private Camera _mainCamera; //메인 카메라
	private CameraMove _mainCameraMove; //메인 카메라의 무브스크립트
	private CharacterController _characterController; //캐릭터 컨트롤러

	public void AddItem(IItem item)
	{
		ItemInventory?.AddItem(item);
		NoticeManager?.Notice(item);
	}

}
