using UnityEngine;
using System.Collections;

public class playerControllerScript : MonoBehaviour 
 {
	
	public float maxSpeed = 10f;		// Player's max run speed.
	bool facingRight = true;			// Whether or not the player is facing right.


	private Animator anim;				// Reference to the Animator on the player

	bool grounded = false;				// Whether or not the player is grounded.
	public Transform groundCheck;		// A position marking where to check if the player is grounded.
	float groundRadius = 0.4f;			// Size of position marking.
	public LayerMask whatIsGround;		// Defines what is ground.
	public float jumpForce = 700f;		// Amount of force added when jumping.

	bool doubleJump = false;			// Whether player is double jumping.

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent <Animator>(); 		// Reference to the player's animator component.
	
	}

	void FixedUpdate () 
	{
		// The player is grounded if the position marking to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		// Grabs current anim parameter Ground from animator
		anim.SetBool ("Ground", grounded);

		// If the jump button is pressed and the player is grounded then the player should jump.
		if (grounded)
			doubleJump = false;

		// Specifies how fast the player moves vertically
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		// Disables player from moving horizontally while jumping in air
		//if (!grounded)return;

		// Set move to horizontal input
		float move = Input.GetAxis ("Horizontal");

		// Set anim parameter Speed to move
		anim.SetFloat ("Speed", Mathf.Abs(move));

		// Add verlocity to the player horizontally
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

		// If player moves right and is not facing right, flip player
		if (move > 0 && !facingRight)
				Flip();
		// If player move left and is facing right, flip player
		else if (move < 0 && facingRight)
				Flip();
	}

	void Update()
	{
		// If player is on ground or not double jumping and press jump
		if ((grounded || !doubleJump) && Input.GetButtonDown ("Jump"))
		{
			// Set anim parameter Ground to false
			anim.SetBool ("Ground", false);
			// Add vertical jump force to player
			rigidbody2D.AddForce (new Vector2(0, jumpForce));
		
			// If player is not double jumping and not on ground, then jump again
			if(!doubleJump && !grounded)
				doubleJump = true;
		}
	}

	// Function to flip player
	void Flip()
	{
		// When label is not facing right, transform by multiplying local scale with -1
		facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}

 }
