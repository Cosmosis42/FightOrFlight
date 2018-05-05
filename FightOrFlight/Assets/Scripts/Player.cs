using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("References")]
	public Transform StartingPosition;

	public HpBar HpBar;
	public StaminaBar StaminaBar;

	public BirdController Controller;

	[Header("Stats")]
	public int MaxHp = 10;
	public int CurrentHp = 10;

	public float MaxStamina;
	public float CurrentStamina;

	public int Damage;

	#region HP and Stamina

	public void AddHp(int value)
	{
		CurrentHp += value;

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

	public void AddStamina(float value)
	{
		CurrentStamina += value;

		// Play relevant animation
		UpdateStaminaBar();
	}

	public void ReduceStamina(float value)
	{
		CurrentStamina -= value;
		// Play relevant animation
		UpdateStaminaBar();
	}

	private void UpdateStaminaBar()
	{
		StaminaBar.SetStamina(CurrentStamina);
	}
	#endregion

	public void MakeAttack()
	{
		// Play animation

		// Get nearby player object.

		// Send attack to player

		// Reduce stamina
		ReduceStamina(1);
	}

	public void FlapWings()
	{
		CurrentStamina -= 1;
	}

	public void Init()
	{
		transform.SetPositionAndRotation(StartingPosition.position, StartingPosition.rotation);

		CurrentHp = MaxHp;
		CurrentStamina = MaxStamina;

		HpBar.Initialize(MaxHp);
		StaminaBar.Initialize(MaxStamina);
	}

	void Update()
	{
		// Regenerate stamina
	}
}

