using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Player : MonoBehaviour 
{
	// how high the character jumps
	// jumpHeight = (gravity * timeToJumpApex²) / 2
	public float jumpHeight = 4;

	// how long need the character to reach the highest point
	public float timeToJumpApex = .4f;

	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;

	// move velocity
	// velocityInitial + gravity * time
	float moveSpeed = 6;

	// jump velocity
	float jumpVelocity;

	// gravity factor
	float gravity;

	Vector3 velocity;

	// the smooth operation will set this value
	float velocityXSmoothing;

	// controller for player object
	Controller controller;

	// this method is called by Unity on start
	void Start () 
	{
		controller = GetComponent<Controller> ();

		// gravity = (2*jumpHeight) / timeToJumpApex² | negative to fall down!
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);

		// jumpVelocity = gravity * timeToJumpApex
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
	}
	
	// update is called once per frame
	void Update () 
	{
		// stop on collision
		if(controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
		}

		// input
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		// button for jumping
		if (Input.GetKeyDown (KeyCode.UpArrow) && controller.collisions.below) 
		{
			velocity.y = jumpVelocity;
		}

		// speed in x direction
		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeGrounded);

		// falling speed
		velocity.y += gravity * Time.deltaTime;

		// move
		controller.Move(velocity * Time.deltaTime);
	}
}
