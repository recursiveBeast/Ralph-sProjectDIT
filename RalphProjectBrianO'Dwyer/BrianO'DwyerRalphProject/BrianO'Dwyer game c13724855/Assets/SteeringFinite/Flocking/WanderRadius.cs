using UnityEngine;
using System.Collections;

public class WanderRadius : MonoBehaviour {

	float angle;
	public Vector3 centre;


	// where is origin

	//make this Vector3 accessible from the flocking2 class or a leader class
	// and head in its direction
	// using same math as seek 

	//parametric equation for a circle
	public Vector3 point;
	public float radius = 1f;
	float x;
	float y; 

	void Start () {
		centre = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		 angle = Random.value/10*Mathf.PI*2;

		x = Mathf.Cos (angle) * radius;
		y = Mathf.Sin (angle) * radius;

		point = new Vector3(x,y,0);
		Debug.Log (point);
	}
}
