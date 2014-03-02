using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
		
		
	bool facingRight = true;
	public float velocityIncrement = .5f;
	public float jumpVelocity = 15f;
	const float maxSpeed = 10f;
	public float maxVelocity = maxSpeed;
	public float minVelocity = -1f * maxSpeed;
	public int maxJumps = 2;
	public int curJumps = 2;
	public bool grounded = false;				// Whether or not the player is grounded.
	public Transform groundCheck;		// A position marking where to check if the player is grounded.
	public float groundRadius = 0.4f;			// Size of position marking.
	public LayerMask whatIsGround;		// Defines what is ground.
	private Animator anim;				// Reference to the Animator on the player

		void Start ()
		{
				anim = GetComponent <Animator> (); 		// Reference to the player's animator component.
		}
	
		// Update is called once per frame
		void Update ()
		{
			
			float direction = Input.GetAxis ("Horizontal");
			
			Vector2 CurrentVelocity = rigidbody2D.velocity;
			Vector2 NewVelocity;

			bool left = ((int)(direction*100) < 0);
			bool right = ((int)(direction*100) > 0);
			bool jump = Input.GetButtonDown ("Jump");
		
			// The player is grounded if the position marking to the groundcheck position hits anything on the ground layer.
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		

			if ((right && !facingRight) || (left && facingRight)){
				Flip ();
			}
			
			if (grounded&&CurrentVelocity.y==0) {
				curJumps = 0;	
			}	
			NewVelocity = CurrentVelocity;
			if (left) {
				NewVelocity.x = CurrentVelocity.x - velocityIncrement; 
				if(NewVelocity.x <= minVelocity){
					NewVelocity.x = minVelocity;
				}
			}
			if (right) {
				NewVelocity.x = CurrentVelocity.x + velocityIncrement; 
				if(NewVelocity.x >= maxVelocity){
					NewVelocity.x = maxVelocity;
				}
			}
			if (!left && !right && grounded) {
				NewVelocity.x = 0;
			}
			if (jump && curJumps<maxJumps) {
				curJumps++;
				NewVelocity.y = jumpVelocity;
			
			}
			Move (NewVelocity);
		
			// Grabs current anim parameter Ground from animator
			anim.SetBool ("Ground", grounded);
			// Specifies how fast the player moves vertically
			anim.SetFloat ("vSpeed", CurrentVelocity.y);
			// Set anim parameter Speed to move
			anim.SetFloat ("Speed", Mathf.Abs(CurrentVelocity.x));
			
			
		
		}

		void Move(Vector2 Velocity){
			rigidbody2D.velocity = new Vector2(Velocity.x,Velocity.y);

		
		}

		void Flip(){
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		
		
		}
		
		



}

