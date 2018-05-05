using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Transform StartingPosition;

	public int MaxHp;

	public int CurrentHp;

	public float MaxStamina;

	public float CurrentStamina;

	public void DoDamage(int damage)
	{
		CurrentHp -= damage;
	}
}

