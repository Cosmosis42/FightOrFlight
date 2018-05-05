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

	}
}

