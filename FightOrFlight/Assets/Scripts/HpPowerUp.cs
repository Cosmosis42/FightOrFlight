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

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			var playerController = other.gameObject.GetComponent<BirdController>();

			Apply(playerController.player);

			Destroy(gameObject);
		}
	}
}
