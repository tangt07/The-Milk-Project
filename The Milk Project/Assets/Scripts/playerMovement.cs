using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
		
		
	bool facingRight = true;
	float Speed = 0f;
	public float jumpVelocity = 15f;
	const float maxSpeed = 10f;
	public float maxVelocity = maxSpeed;
	public float minVelocity = -1f * maxSpeed;
	public int maxJumps = 2;
	public int curJumps = 0;
	public bool grounded = false;				// Whether or not the player is grounded.
	public Transform groundCheck;		// A position marking where to check if the player is grounded.
	float groundRadius = 0.4f;			// Size of position marking.
	public LayerMask whatIsGround;		// Defines what is ground.
	private Animator anim;				// Reference to the Animator on the player

		void Start ()
		{
			anim = GetComponent <Animator>(); 		// Reference to the player's animator component.
		}
	
		// Update is called once per frame
		void Update ()
		{
			
			float move = Input.GetAxis ("Horizontal");

			if (move > 0 && !facingRight)
				Flip();
			// If player move left and is facing right, flip player
			else if (move < 0 && facingRight)
				Flip();
		
			if (Input.GetButtonDown ("Jump") && ++curJumps < maxJumps) {
				
				Move (xVelocity (move), jumpVelocity);
			}
			else {				
				Move (xVelocity(move), rigidbody2D.velocity.y);
			}

			// The player is grounded if the position marking to the groundcheck position hits anything on the ground layer.
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

			if (grounded) {
				curJumps = 0;
			}
			// Grabs current anim parameter Ground from animator
			anim.SetBool ("Ground", grounded);
			// Specifies how fast the player moves vertically
			anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
			// Set anim parameter Speed to move
			anim.SetFloat ("Speed", Mathf.Abs(xVelocity(move)));
			
		
		}
		
		void Jump(){
			Debug.Log ("jump pressed");

		}
	void Move(float xVelocity, float yVelocity){
		rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
		// If player moves right and is not facing right, flip player

		
	}
	float xVelocity(float move){
		float xVel = rigidbody2D.velocity.x;
		if (.5f * move + xVel >= maxVelocity) 
			return maxVelocity;
		else if (.5f* move +xVel <= minVelocity)
			return minVelocity;
		else
			return .5f * move + xVel;
	}
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		
		
	}
		
		



}

