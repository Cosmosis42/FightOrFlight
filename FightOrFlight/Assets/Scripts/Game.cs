using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using UnityEngine;

public class Game : MonoBehaviour
{
	public static Game Instance;

	public Player Player1;

	public Player Player2;

	public EndOfGameScreen EndScreen;

	public GameObject featherEffectPrefab;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		StartGame();

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

	public void DropFeathers(Vector3 position)
	{
		Instantiate(featherEffectPrefab, position, Quaternion.identity);
	}

	public void TestFeathers()
	{
		DropFeathers(Vector3.zero);
	}

	public void EndGame(Player loser)
	{
		string winnerString;
		if (loser == Player1)
			winnerString = "PLAYER 2 WINS!";
		else
			winnerString = "PLAYER 1 WINS!";
		EndScreen.gameObject.SetActive(true);
		EndScreen.Initialize(winnerString);

	}
}

