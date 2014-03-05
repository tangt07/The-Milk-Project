using UnityEngine;
using System.Collections;

public class playerCollisions : MonoBehaviour
{
	public Health playerhealth;
	GameObject player;
	// Use this for initialization
	void Start ()
	{
		player = gameObject;
		playerhealth = player.GetComponent<Health>();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.J)) {
			playerhealth.TakeDamage(52);
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			playerhealth.Revive();
			Example();

		}

	
	}
	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log (collision.gameObject);
		Enemy e;
		e = collision.gameObject.GetComponent<Enemy> ();
		if(e != null){

		}
	}
	IEnumerator Example() {
		print("Starting " + Time.time);
		yield return WaitAndPrint();
		print("Done " + Time.time);
	}

	IEnumerator WaitAndPrint() {
		yield return new WaitForSeconds(5);
		print("WaitAndPrint " + Time.time);
	}

}

