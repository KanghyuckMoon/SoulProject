using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class GameOverUIManager : MonoBehaviour
{
	[SerializeField]
	private Canvas _gameOverUICanavas;

	[SerializeField]
	private Image _background;
	[SerializeField]
	private TextMeshProUGUI _gameOverText;
	[SerializeField]
	private Button _retryButton;
	[SerializeField]
	private Button _moveMainButton;

	public void Start()
	{
		_retryButton.onClick.AddListener(() => Retry());
		_moveMainButton.onClick.AddListener(() => MoveToMain());
	}

	/// <summary>
	/// 게임오버씬 설정
	/// </summary>
	public void Setting()
	{

		_gameOverUICanavas.gameObject.SetActive(true);
		_gameOverText.gameObject.SetActive(true);
		_background.color = new Color(0, 0, 0, 0);
		_background.DOFade(1, 0.5f).SetUpdate(true).SetDelay(0.5f);
		Vector2 originPos = _gameOverText.rectTransform.anchoredPosition;
		originPos.y -= Screen.height;
		_gameOverText.rectTransform.anchoredPosition = originPos;
		_gameOverText.rectTransform.DOAnchorPos(Vector2.zero, 1f).SetEase(Ease.OutQuad).SetDelay(1.5f).SetUpdate(true).OnComplete(() => SetActiveButton()).SetDelay(0.5f);
	}

	/// <summary>
	/// 게임오버 버튼 활성화
	/// </summary>
	private void SetActiveButton()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		_retryButton.gameObject.SetActive(true);
		_moveMainButton.gameObject.SetActive(true);
	}

	/// <summary>
	/// 게임 오버시 다시 시작
	/// </summary>
	private void Retry()
	{
		LoadingManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	/// <summary>
	/// 타이틀 씬으로 이동
	/// </summary>
	private void MoveToMain()
	{

	}

}
