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
}

