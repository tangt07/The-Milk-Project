using UnityEngine;
using System.Collections;

public class PowerStates : MonoBehaviour {
	public int powerstate=0;
	public Collider2D Strawberry;
	public Collider2D Chocolate;
	private Animator anim;
	Health playerhealth;
	playerMovement playermovement;
	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> (); 		// Reference to the player's animator component.

		playerhealth = GetComponent<Health>();
		playermovement = GetComponent<playerMovement> ();
	
	}

	// Update is called once per frame
	void Update () {

		}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider == Chocolate) {
			Debug.Log("hit chocolate");
			playerhealth.invulnerable = true;			
			anim.SetTrigger("PowerUpNC");
			playermovement.maxJumps = 2;

		}
		if (collision.collider == Strawberry) {
			Debug.Log("hit strawberry");
			playerhealth.invulnerable = true;		
			anim.SetTrigger("PowerUpNS");
			playermovement.maxJumps = 1;

		}

	}
}
