using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject player;
	public float minsize=2f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 playerposition = player.transform.position;
		if(playerposition.y > 2f*minsize-3f){
		transform.position = new Vector3(playerposition.x,.5f*playerposition.y-.5f,-10);
		camera.orthographicSize = .5f*playerposition.y+1.5f;
		}
		else{
			transform.position = new Vector3(playerposition.x,minsize-2,-10);
			camera.orthographicSize = minsize;

		}
		//size position maxheightplayer
		//2 0 1
		//3 1 3
		//4 2 4.9
		//5 3 7
	}
}
