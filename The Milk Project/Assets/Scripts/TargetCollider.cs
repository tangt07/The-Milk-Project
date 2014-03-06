using UnityEngine;
using System.Collections;

public class TargetCollider : MonoBehaviour {
	Health healthscript;
	public static Hashtable takesDamage;
	// Use this for initialization
	void Start () {
		healthscript = gameObject.transform.parent.GetComponent<Health>();
		takesDamage = new Hashtable ();
		takesDamage.Add ("Player", 100f);
		takesDamage.Add ("Enemy_RE", 10f);



	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("other collider: " +collider.name + " : " + collider.tag);
		Debug.Log ("this collider: " + gameObject.transform.parent.name + " : " + gameObject.transform.parent.tag);
		
		if (collider.tag != gameObject.transform.parent.tag) {
			//Debug.Log (collider.name);
			//otherhealthscript = collider.GetComponent<Health>();
			if(takesDamage[collider.name] != null){
				Debug.Log (takesDamage[collider.name]);
				healthscript.TakeDamage((float)takesDamage[collider.name]);
			}
		}
	}

}
