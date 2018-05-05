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
    public float flapStren = 10;
    public float diveStren = 10;
    public float moveSpeed = 10;
    public float maxSpeed = 250;
    public float wallLeft, wallRight, floor, roof, bounciness;

    [Header("Controls")]
    public string flyCon = "Fly";
    public string runCon = "Run";
    public string diveCon = "Dive";

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
            rb2D.AddForce(transform.up * flapStren);
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton(diveCon))
        {
            rb2D.AddForce(transform.up * -diveStren);
        }

        //Pressing the right or left buttons will move you in that direction
        if (Input.GetKey("d")) // Right
        {
            facing = Direction.RIGHT;
            rb2D.AddForce(transform.right * moveSpeed);
        }
        else if (Input.GetKey("a")) // Left
        {
            facing = Direction.LEFT;
            rb2D.AddForce(transform.right * -moveSpeed);
        }

        // Using a joystick for movement
        if (Input.GetAxis(runCon) != 0)
        {
            if(Input.GetAxis(runCon) < 0)
            {
                facing = Direction.LEFT;
            }
            else
            {
                facing = Direction.RIGHT;
            }

            rb2D.AddForce(transform.right * moveSpeed * Input.GetAxis(runCon));
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
    }
}
