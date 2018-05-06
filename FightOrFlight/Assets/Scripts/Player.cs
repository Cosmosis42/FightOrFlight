using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[Header("References")]
	public Transform StartingPosition;

	public HpBar HpBar;
	public Text PowerUpText;

	public BirdController Controller;

	[Header("Stats")]
	public int MaxHp = 10;
	public int CurrentHp = 10;

	public float MaxStamina = 10;
	public float CurrentStamina = 10;
	public float StaminaRegen = 2;

	#region Damage and speed
	public float FlapStrength = 10;
	public int Damage = 1;

	public APowerUpEffect ActiveEffect;
	private float _effectCountDownTimer = 0f;

	public float GetFlapStrength()
	{
		if (ActiveEffect is SpeedBoost)
			return FlapStrength + (float)ActiveEffect.Value;
		return FlapStrength;
	}

	public int GetDamage()
	{
		if (ActiveEffect is DamageBoost)
			return Damage + (int)ActiveEffect.Value;
		return Damage;
	}

	public void ApplyEffect(APowerUpEffect effect)
	{
		ActiveEffect = effect;

		_effectCountDownTimer = ActiveEffect.Duration;

		PowerUpText.text = effect.GetDisplayString();
	}


	#endregion

	#region HP and Stamina

	public void AddHp(int value)
	{
		CurrentHp += value;

		if (CurrentHp > MaxHp)
			CurrentHp = MaxHp;

		// Play relevant effect

		UpdateHpBar();
	}

	public void ReduceHp(int value)
	{
		CurrentHp -= value;
		// Play relevant effect

		UpdateHpBar();
	}

	private void UpdateHpBar()
	{
		HpBar.SetCurrentLife(CurrentHp);
	}
	#endregion

	public void Attack(Player attacker)
	{
		// Play animation

		// Get nearby player object.

		// Send attack to player
		ReduceHp(attacker.GetDamage());

	}

	public void SpikeDamage()
	{
		// Play animation

		// Get nearby player object.

		// Send attack to player
		ReduceHp(Damage);
	}

	public void Init()
	{
		Controller.transform.SetPositionAndRotation(StartingPosition.position, StartingPosition.rotation);

		CurrentHp = MaxHp;

		HpBar.Initialize(MaxHp);
	}

	void Update()
	{
		if (ActiveEffect != null)
		{
			_effectCountDownTimer -= Time.deltaTime;

			if (_effectCountDownTimer <= 0)
			{
				ActiveEffect = null;
				PowerUpText.text = string.Empty;
			}
		}
	}
}

