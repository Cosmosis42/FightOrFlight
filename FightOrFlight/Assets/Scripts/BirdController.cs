using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction
{
	LEFT, RIGHT
}

public class BirdController : MonoBehaviour
{
	private Rigidbody2D rb2D;
	private Direction facing = Direction.RIGHT;
	private bool dashing = false;
	public bool grappled = false;
	private bool grapCooldown = false;
	public bool onGround = true;
	public float dashCooldown = 2;
	public float flapStren = 10;
	public float maxSpeed = 250;
	public float dashSpeed = 100;
	public float wallLeft, wallRight, floor, roof, bounciness, dashTime, grapTime;
	public BirdAnimator.BirdAnimations birdState;

	[Header("References")]
	public Player player;

	[Header("Controls")]
	public string flyCon = "Fly";
	public string runCon = "Run";
	public string LDash = "LDash";
	public string RDash = "RDash";
	public string vertCon = "Vertical";
	public string Grab = "Grab";

	[Header("Sounds")]
	public AudioClip[] kungFu;
	public AudioClip[] miss;
	private AudioSource audioSource;

	private float _flapCounter = 0;

	// Use this for initialization
	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		// Don't let velocity exceed maxSpeed
		rb2D.velocity = Vector3.ClampMagnitude(rb2D.velocity, maxSpeed);

		// Pressing space will flap your wings, giving you upward thrust
		// Pressing shift will give you downward thrust
		if (Input.GetButtonDown(flyCon))
		{
			birdState = BirdAnimator.BirdAnimations.Flap;
			_flapCounter = 0.5f;
			Vector2 flyDir = new Vector2(Input.GetAxis(runCon), Input.GetAxis(vertCon));
			flyDir.Normalize();
			rb2D.AddForce(flyDir * flapStren);

			if (Input.GetAxis(runCon) > 0)
				facing = Direction.RIGHT;
			else
				facing = Direction.LEFT;
		}

		if (birdState == BirdAnimator.BirdAnimations.Flap)
		{
			_flapCounter -= Time.deltaTime;
			if (_flapCounter <= 0)
			{
				if (!onGround)
					birdState = BirdAnimator.BirdAnimations.Fly;
				else
					birdState = BirdAnimator.BirdAnimations.Idle;
			}
		}

		// If the bird goes outside of bounds, move it to the other side
		if (transform.position.x < wallLeft)
		{
			Vector3 newPos = new Vector3(wallRight, transform.position.y, transform.position.z);

			transform.SetPositionAndRotation(newPos, transform.rotation);
		}
		else if (transform.position.x > wallRight)
		{
			Vector3 newPos = new Vector3(wallLeft, transform.position.y, transform.position.z);

			transform.SetPositionAndRotation(newPos, transform.rotation);
		}
		else if (transform.position.y < floor)
		{
			Vector3 newPos = new Vector3(transform.position.x, roof, transform.position.z);

			transform.SetPositionAndRotation(newPos, transform.rotation);
		}

		if (transform.childCount != 0 && Input.GetAxis(Grab) == 0)
		{
			transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = true;
			transform.GetChild(0).parent = null;
		}

		// Use the bumpers to dash left and right
		if (Input.GetButtonDown(RDash) || Input.GetButtonDown(LDash))
		{
			if (grappled && !grapCooldown)
			{
				transform.parent = null;
				rb2D.simulated = true;
			}

			StartCoroutine(Dash(dashTime, dashCooldown));
		}

		// When you die, do stuff
		if (player.CurrentHp <= 0)
		{
			Destroy(this);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		// MAke the birb face the right way
		if (facing == Direction.LEFT)
			GetComponent<SpriteRenderer>().flipX = true;
		else
			GetComponent<SpriteRenderer>().flipX = false;
	}

	public IEnumerator Dash(float time, float cooldown)
	{
		int sound;

		if (!dashing)
		{
			dashing = true;

			sound = (int)Random.Range(0.0f, miss.Length);

			audioSource.PlayOneShot(miss[sound]);

			if (Input.GetAxis(runCon) > 0)
				facing = Direction.RIGHT;
			else if (Input.GetAxis(runCon) < 0)
				facing = Direction.LEFT;

			Vector2 dir = new Vector2(Input.GetAxis(runCon), Input.GetAxis(vertCon));
			rb2D.velocity = dir.normalized * dashSpeed;

			yield return new WaitForSeconds(time);

			rb2D.velocity = new Vector2(0.0f, 0.0f);

			yield return new WaitForSeconds(cooldown);

			dashing = false;
		}
	}

	public IEnumerator Grappled(float time)
	{
		grapCooldown = true;

		yield return new WaitForSeconds(time);

		grapCooldown = false;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		int sound;

		if (collision.gameObject.tag == "Player")
		{
			if (Input.GetAxis(Grab) == 0)
			{
				if (dashing)
				{
					print(message: "You have damaged " + collision.gameObject.name);

					sound = (int)Random.Range(0.0f, kungFu.Length);

					audioSource.PlayOneShot(kungFu[sound]);

					var otherPlayer = collision.gameObject.GetComponent<BirdController>();

					if (otherPlayer != null)
					{
						otherPlayer.player.Attack(player);
						Game.Instance.DropFeathers(collision.transform.position);
					}
					else
					{
						Game.Instance.DropFeathers(transform.position);
					}
				}
			}

			if (Input.GetAxis(Grab) != 0)
			{
				Vector3 contactPoint = collision.contacts[0].point;
				Vector3 center = collision.collider.bounds.center;

				bool top = contactPoint.y > (center.y + (collision.transform.lossyScale.y / 2.25));
				bool middle = (contactPoint.x < (center.x + collision.transform.lossyScale.x / 2)
								   && contactPoint.x > center.x - (collision.transform.lossyScale.x / 2));

				if (top && middle)
				{
					collision.rigidbody.simulated = false;
					collision.transform.parent = transform;
					collision.gameObject.GetComponent<BirdController>().grappled = true;
				}
				StartCoroutine(collision.gameObject.GetComponent<BirdController>().Grappled(grapTime));
			}
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Platform")
		{
			onGround = true;
			birdState = BirdAnimator.BirdAnimations.Idle;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Platform")
		{
			onGround = false;
			birdState = BirdAnimator.BirdAnimations.Fly;
		}
	}

	public BirdAnimator.BirdAnimations GetBirdState()
	{
		return birdState;
	}
}
