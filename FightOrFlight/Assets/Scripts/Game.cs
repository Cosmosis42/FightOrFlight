using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Game : MonoBehaviour
{
	public static Game Instance;

	public Player Player1;

	public Player Player2;

	void Awake()
	{
		Instance = this;
	}

	void OnDestroy()
	{
		Instance = null;
	}

	public void StartGame()
	{
		// Initialize players
		Player1.Init();
		Player2.Init();

		// Initialize HP bars
		// Player animation
	}

	public void RegisterAttack(Player player)
	{
		// Figure out if birb is in range.
		Player other;
		if (player == Player1)
			other = Player2;
		else
			other = Player1;

		// IF IN RANGE
		// Apply damage
		// Play UI animations
	}

}

