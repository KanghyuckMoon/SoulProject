using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoonLibrary.DesignPattern;

public class MonsterPanel : MonoBehaviour, IObserver
{
	public Player Player
	{
		get
		{
			_player ??= FindObjectOfType<Player>();
			return _player;
		}
		set
		{
			_player = value;
		}
	}

	[SerializeField]
	private TextMeshProUGUI _nameText = null;
	[SerializeField]
	private TextMeshProUGUI _descriptionText = null;
	[SerializeField]
	private TextMeshProUGUI _levelText = null;
	[SerializeField]
	private TextMeshProUGUI _hpText = null;
	[SerializeField]
	private TextMeshProUGUI _spdText = null;
	[SerializeField]
	private TextMeshProUGUI _atkText = null;
	[SerializeField]
	private TextMeshProUGUI _defText = null;
	[SerializeField]
	private TextMeshProUGUI _expText = null;
	[SerializeField]
	private Button _fastLevelUPButton = null;
	[SerializeField]
	private TextMeshProUGUI _needMoneyText = null;
	[SerializeField]
	private MoneySO _playerMoneySO = null;
	[SerializeField]
	private Image _monsterImage = null;
	[SerializeField]
	private Image _monsterHPImage = null;
	[SerializeField]
	private Image _expImage = null;

	private Player _player = null;



	public void Start()
	{
		_playerMoneySO.AddObserver(this);
		_fastLevelUPButton.onClick.AddListener(() => OnFastLevelUP());
	}

	public void OnEnable()
	{
		Setting(Player);
	}

	public void Setting(Player player)
	{
		if(player.CaptureMonster == null)
		{
			_nameText.text = "None";
			_descriptionText.text = "빙의한 몬스터가 없습니다";
			_levelText.text = "LV.0";
			_hpText.text = "HP: 0";
			_atkText.text = "ATK: 0";
			_spdText.text = "SPD: 0";
			_defText.text = "DEF: 0";
			_expText.text = "EXP) 0/0";
			_fastLevelUPButton.interactable = false;
			_needMoneyText.text = "0";
			_monsterImage.sprite = null;
			_monsterHPImage.sprite = null;
			_expImage.fillAmount = 0;
		}
		else
		{
			IMonster monster = player.CaptureMonster;
			_nameText.text = monster.Name;
			_descriptionText.text = monster.Description;
			_levelText.text = $"LV.{monster.Level}";
			_hpText.text = $"HP: {monster.MaxHP}";
			_atkText.text = $"ATK: {monster.ATK}";
			_spdText.text = $"SPD: {monster.SPD}";
			_defText.text = $"DEF: {monster.DEF}";
			_expText.text = $"EXP) {monster.EXP}/{monster.Level * 10}";
			_monsterImage.sprite = monster.Sprite;
			_monsterHPImage.sprite = monster.Sprite;
			_monsterHPImage.fillAmount = (float)(monster.MaxHP - monster.HP) / monster.MaxHP;
			_expImage.fillAmount = 1 / (monster.Level * 10);

			int needMoney = monster.Level * 10 - monster.EXP;
			_needMoneyText.text = $"{needMoney}";
			if(needMoney <= _playerMoneySO._money)
			{
				_fastLevelUPButton.interactable = true;
			}
			else
			{
				_fastLevelUPButton.interactable = false;
			}

			if(monster.CheckMaxLevel())
			{
				_fastLevelUPButton.interactable = false;
				_needMoneyText.text = $"MAX";
			}
		}
	}

	public void GetNotify()
	{
		Setting(Player);
	}

	public void OnFastLevelUP()
	{
		if (Player.CaptureMonster != null)
		{
			IMonster monster = Player.CaptureMonster;
			if (monster.CheckMaxLevel())
			{
				return;
			}
			_playerMoneySO.AddMoney(-(monster.Level * 10 - monster.EXP));
			monster.LevelUP();
			Setting(Player);
		}
	}
}
