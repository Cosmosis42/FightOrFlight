using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class EndOfGameScreen : MonoBehaviour
	{
		public Button Continue;
		public Button Exit;
		public Text WinnerText;

		public void Initialize(string winner)
		{
			Continue.Select();
			WinnerText.text = winner;
		}

		public void EndGame()
		{
			Application.Quit();
		}

		public void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
