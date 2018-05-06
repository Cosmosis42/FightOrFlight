using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HpPowerUp : MonoBehaviour
{
	public PowerUpSpawner Spawner;

	public int Value;

	public void Apply(Player player)
	{
		player.AddHp(Value);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			var playerController = collision.gameObject.GetComponent<BirdController>();

			Apply(playerController.player);

			Destroy(gameObject);
		}
	}
}
