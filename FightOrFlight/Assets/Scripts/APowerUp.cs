using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class APowerUp : MonoBehaviour
{
	public PowerUpSpawner Spawner;

	public abstract void Apply(Player player);

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			var playerController = collision.gameObject.GetComponent<BirdController>();

			Apply(playerController.player);

			Spawner.ResetTimer();

			Destroy(gameObject);
		}
	}
}

