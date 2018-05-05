using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
    private Rigidbody2D rb2D;
    public float flapStren = 10;
    public float moveSpeed = 10;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // Pressing space will flap your wings, giving you upward thrust
        if (Input.GetKeyDown("space"))
        {
            rb2D.AddForce(transform.up * flapStren);
        }
        
        // Pressing the right or left buttons will move you in that direction
        if (Input.GetKeyDown("D")) // Right
        {
            rb2D.
        }
        else if (Input.GetKeyDown("A")) // Left
        {

        }
    }
}
