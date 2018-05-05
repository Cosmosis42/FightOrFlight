using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Debug.Log("Spikes have damage " + collision.gameObject.name);

			var player = collision.gameObject.GetComponent<BirdController>();

			if (player != null)
			{
				player.player.SpikeDamage();
				Game.Instance.DropFeathers(collision.transform.position);
			}
		}
	}
}
