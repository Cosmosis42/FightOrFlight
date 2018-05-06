using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	Rigidbody2D rb2D;
	private Vector3 newPos;
	public float left, right, speed;
	private float jump;
	public AudioClip[] kungFu;
	private AudioSource audioSource;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		rb2D.velocity = new Vector2(speed, 0.0f);
		audioSource = GetComponent<AudioSource>();
	}

	private void FixedUpdate()
	{

		if (transform.position.x > right)
		{
			newPos = new Vector3(right, transform.position.y, transform.position.z);
			transform.SetPositionAndRotation(newPos, transform.rotation);

			rb2D.velocity *= -1;
			GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (transform.position.x < left)
		{
			newPos = new Vector3(left, transform.position.y, transform.position.z);
			transform.SetPositionAndRotation(newPos, transform.rotation);

			rb2D.velocity *= -1;
			GetComponent<SpriteRenderer>().flipX = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		int sound;

		if (collision.gameObject.tag == "Player")
		{ 
			Debug.Log("Spikes have damage " + collision.gameObject.name);

			sound = (int)Random.Range(0.0f, kungFu.Length);

			audioSource.PlayOneShot(kungFu[sound]);

			var player = collision.gameObject.GetComponent<BirdController>();

			if (player != null)
			{
				player.player.SpikeDamage();
				Game.Instance.DropFeathers(collision.transform.position);
			}
		}
	}
}
