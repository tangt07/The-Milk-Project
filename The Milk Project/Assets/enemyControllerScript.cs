using UnityEngine;
using System.Collections;

public class enemyControllerScript : MonoBehaviour {
	private bool gotHurt = false;

	// Use this for initialization
	void Awake () {
		gotHurt = GameObject.Find("headCollider").GetComponent<colliderScript>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//got Hurt = colliderScript.gotHit
	}
}
