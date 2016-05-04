using UnityEngine;
using System.Collections;

public class FeelerChild : MonoBehaviour {

	// Use this for initialization
	public GameObject Feeler;
	float x;
	float y;
	bool canMove = true;
	Transform t;
	Vector3 moveDir;

	void Start () {
		//x = Feeler.transform.position.x += Random.value * 10;
	    //y = Feeler.transform.position.y += Random.value * 10;
		//t = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
		if (canMove == true) {
		//	moveDir.x += new Vector3 (Feeler.transform.position.x += Random.value * 10, 0, 0 );
		//	moveDir.y += new Vector3 (x, Feeler.transform.position.y += Random.value * 10,0);

			transform.position = moveDir;

			Invoke ("Reset", 2);
		}

		canMove = false;

	}

	void reset(){
		canMove = true;
	}
}
