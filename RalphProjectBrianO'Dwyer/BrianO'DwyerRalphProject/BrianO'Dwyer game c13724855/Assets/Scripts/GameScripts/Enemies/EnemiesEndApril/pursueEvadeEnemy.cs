using UnityEngine;
using System.Collections;

public class pursueEvadeEnemy : MonoBehaviour {


	float maxPrediction, maxSpeed;
	Rigidbody rb;
	Vector3 desiredVelocity;
	public GameObject showTarget;
	public GameObject bullet;



	// This will pursue player and evade player's bullets at the same time
	//It will take the closest bullet to it 
	 // Or will it avoid whichever way the player is facing ?? 
	// Steer away from whichever way the player faces and the bullets!.. better



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 Persue(GameObject targetObject){
		float prediction;
		Vector3 direction = targetObject.transform.position - transform.position;
		float dist = direction.magnitude;
		float speed = rb.velocity.magnitude;
		if (speed <= dist / maxPrediction) {
			prediction = maxPrediction;
		} else {
			prediction = dist / speed;
		}
		Vector3 newTarget = targetObject.transform.position;
		Vector3 targetVel = new Vector3();
		Rigidbody2D targetRB = targetObject.GetComponent<Rigidbody2D> ();
		if (targetRB != null) {
			targetVel = targetRB.velocity;
		}
		newTarget += targetVel * prediction;
		showTarget.transform.position = newTarget;
		return Seek (newTarget);
	}



	public Vector3 Seek(Vector3 seekTarget){

		desiredVelocity = seekTarget - transform.position;
		desiredVelocity.Normalize ();
		desiredVelocity *= maxSpeed ;
		if (rb.velocity.magnitude > maxSpeed) {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
		transform.up = desiredVelocity;
		return desiredVelocity - (Vector3)rb.velocity; 
	}



}
