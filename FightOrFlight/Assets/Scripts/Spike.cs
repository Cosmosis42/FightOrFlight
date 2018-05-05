using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	Rigidbody2D rb2D;
	private Vector3 newPos;
	public float left, right, speed, vertPos;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		rb2D.velocity = new Vector2(speed, 0.0f);
	}

	private void FixedUpdate()
	{

		if (transform.position.x > right)
		{
			newPos = new Vector3(right, vertPos, transform.position.z);
			transform.SetPositionAndRotation(newPos, transform.rotation);

			rb2D.velocity *= -1;
		}
		else if (transform.position.x < left)
		{
			newPos = new Vector3(left, vertPos, transform.position.z);
			transform.SetPositionAndRotation(newPos, transform.rotation);

			rb2D.velocity *= -1;
		}

		newPos = new Vector3(transform.position.x, vertPos, transform.position.z);
		transform.SetPositionAndRotation(newPos, transform.rotation); 
	}

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
