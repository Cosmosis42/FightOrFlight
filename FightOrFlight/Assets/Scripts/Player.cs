using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Transform StartingPosition;

	public HpBar HpBar;

	public int MaxHp;

	public int CurrentHp;

	public float MaxStamina;

	public float CurrentStamina;

	public void DoDamage(int damage)
	{
		CurrentHp -= damage;

		HpBar.SetCurrentLife(CurrentHp);
	}

	public void MakeAttack()
	{
		// Notify game class of attack.

		// Reduce stamina
	}

	public void FlapWings()
	{
		CurrentStamina -= 1;

		//
	}

	public void Init()
	{
		transform.SetPositionAndRotation(StartingPosition.position, StartingPosition.rotation);
	}


}

