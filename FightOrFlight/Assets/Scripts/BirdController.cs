using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    LEFT, RIGHT
}

public class BirdController : MonoBehaviour {
    private Rigidbody2D rb2D;
    private Direction facing = Direction.RIGHT;
    private bool dashing = false;
    public float flapStren = 10;
    public float maxSpeed = 250;
    public float dashSpeed = 100;
    public float wallLeft, wallRight, floor, roof, bounciness, dashTime;

    [Header("Controls")]
    public string flyCon = "Fly";
    public string runCon = "Run";
    public string LDash = "LDash";
    public string RDash = "RDash";
    public string vertCon = "Vertical";

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

        // Don't let velocity exceed maxSpeed
        rb2D.velocity = Vector3.ClampMagnitude(rb2D.velocity, maxSpeed);

        // Pressing space will flap your wings, giving you upward thrust
        // Pressing shift will give you downward thrust
        if (Input.GetKeyDown("space") || Input.GetButtonDown(flyCon))
        {
            Vector2 flyDir = new Vector2(Input.GetAxis(runCon), Input.GetAxis(vertCon));
            flyDir.Normalize();
            rb2D.AddForce(flyDir * flapStren);

            if (Input.GetAxis(runCon) > 0)
                facing = Direction.RIGHT;
            else
                facing = Direction.LEFT;

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

        // Use the bumpers to dash left and right
        if (Input.GetButtonDown(RDash) || Input.GetButtonDown(LDash))
            StartCoroutine(Dash(dashTime));
    }

    public IEnumerator Dash(float time)
    {
        if (!dashing)
        {
            dashing = true;

            if (Input.GetAxis(runCon) > 0)
                facing = Direction.RIGHT;
            else if (Input.GetAxis(runCon) < 0)
                facing = Direction.LEFT;

            Vector2 dir = new Vector2(Input.GetAxis(runCon), Input.GetAxis(vertCon));
            rb2D.velocity = dir.normalized * dashSpeed;

            yield return new WaitForSeconds(time);

            rb2D.velocity = new Vector2(0.0f, 0.0f);

            dashing = false;
        }
    }
}
