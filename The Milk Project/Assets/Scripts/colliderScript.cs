using UnityEngine;
using System.Collections;

public class colliderScript : MonoBehaviour {
	bool gotHit = false;

	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (gameObject.tag == "Player");
		gotHit = true;
		//Debug.Log (gotHit);
		//Debug.Log ("it's true");

	}
}
