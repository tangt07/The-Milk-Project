using UnityEngine;
using System.Collections;

public class colliderScript : MonoBehaviour {

	private Animator anim;

	void awake ()
	{
		anim = transform.parent.GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("whoa there!");

		anim.SetTrigger("Die");

		//anim.SetTrigger("Die");
		//Destroy(transform.parent.gameObject);

	}
}
