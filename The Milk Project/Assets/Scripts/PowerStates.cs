using UnityEngine;
using System.Collections;

public class PowerStates : MonoBehaviour {
	public int powerstate=0;
	public Collider2D Strawberry;
	public Collider2D Chocolate;
	private Animator strawberryanim, chocolateanim, anim;
	Health playerhealth;
	// Use this for initialization
	void Start () {
		strawberryanim = Strawberry.gameObject.GetComponent <Animator> (); 		// Reference to the player's animator component.
		chocolateanim = Chocolate.gameObject.GetComponent <Animator> (); 		// Reference to the player's animator component.
		anim = GetComponent <Animator> (); 		// Reference to the player's animator component.

		playerhealth = GetComponent<Health>();

	
	}

	// Update is called once per frame
	void Update () {

		}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider == Chocolate) {
			Debug.Log("hit chocolate");
			playerhealth.invulnerable = true;			
			powerstate=1;
			anim.SetTrigger("PowerUpNC");
			anim.SetInteger("PowerState", 1);
			
		}
		if (collision.collider == Strawberry) {
			Debug.Log("hit strawberry");
			playerhealth.invulnerable = true;		
			powerstate=2;
			anim.SetTrigger("PowerUpNS");
			anim.SetInteger("PowerState", 2);

		}

	}
}
