

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	float maxhealth;
	float minhealth = 0;
	public float health;
	public bool dead = false;
	private Animator anim;				// Reference to the Animator on the player
	playerMovement playermovement;
	string currentTag;
	public bool invulnerable = false;

	void Update () {


	}


	// Use this for initialization
	void Start ()
	{
		currentTag = gameObject.tag;
		if (currentTag == "Player") {
			maxhealth = 100f;
			SetHealth(maxhealth);
			playermovement = gameObject.GetComponent<playerMovement>();
			playermovement.enable = true;

		}
		
		if (currentTag == "Enemy") {
			maxhealth = 100f;
			SetHealth(maxhealth);
		}
		anim = GetComponent <Animator> (); 		// Reference to the player's animator component.


	}
	
	private void SetHealth(float health){
	
		this.health = health;
		DeadCheck ();
	}
	private void AdjustHealth(float adjustment){

		health += adjustment;
		DeadCheck();	
	}
	public void TakeDamage(float damage){
		if(!invulnerable){
			AdjustHealth (-damage);

		}
		else{
			//took damage with powerup
			invulnerable = false;
			playermovement.maxJumps = 1;

		}			
		anim.SetTrigger("Hurt");

	}
	public void Revive(){
		SetHealth (maxhealth);
	}
	private void DeadCheck(){
		if (health <= minhealth) {
			health = minhealth;
			if(!dead){
				dead=true;
				anim.SetBool("Ground",true);
				anim.SetTrigger("Die");
				//anim.CrossFade("MP_die",0f);
				//Destroy(gameObject,3f);
				if(currentTag == "Player"){
					playermovement.Move(Vector2.zero);
					playermovement.enable = false;
				}
			}
		}
		else{

			if(dead){
				dead=false;
				//Revive
				if(currentTag == "Player"){
					playermovement.enable=true;
				}
			}
		}



		
	}






	
	
}

