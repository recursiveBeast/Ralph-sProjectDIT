using UnityEngine;
using System.Collections;

public class WanderBasic : MonoBehaviour {

	public Vector3 point;
	float x;
	float y;
	bool canMove = true;
	// Update is called once per frame

	void Update () {
		if (canMove == true) {
			newDir();
		}


	}


	void newDir(){
		x = (transform.position.x + Random.value*10 );
		y = (transform.position.y + Random.value*10 );

		point = new Vector3 (x,y,0);

		canMove = false;
		Invoke ("reset", 3);
	}

	void reset(){
	
		canMove = true;
	}
}
