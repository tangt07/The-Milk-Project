using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject player;
	public float minsize=2f;
	public float currentsize;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 playerposition = player.transform.position;
		if(playerposition.y > 2f*minsize-3f){
			transform.position = new Vector3(playerposition.x,.5f*playerposition.y-.5f,-10);
			camera.orthographicSize = .5f*playerposition.y+1.5f;
			currentsize = .5f*playerposition.y+1.5f;		
		}
		else{
			transform.position = new Vector3(playerposition.x,minsize-2f,-10f);
			camera.orthographicSize = minsize;
			currentsize = minsize;
		}
		if (playerposition.x < (currentsize * 1.33f - 5.94f)) {
			transform.position = new Vector3(currentsize * 1.33f - 5.935f,transform.position.y,-10f);
			camera.orthographicSize = currentsize;
		}
		
		//y
		//size position maxheightplayer
		//2 0 1
		//3 1 3
		//4 2 4.9
		//5 3 7
		//x
		//4.564765 0.1492335	1.38035 1.8460385  -5.9315959153277278312734057710818
		//3.184415 -1.696805	0.505579 0.659931
		//2.678836 -2.356736	.678836 0.918942
		//2	-3.275678   -5.9399245832428669314007230691414
		//1.3321232916214334657003615345707 avg change
		//size * avgchange = position  -> position = size*1.33 -5.935
		//minsize * 1.333f - 5.935f
	}
}
