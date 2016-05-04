using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FSMEnemy : MonoBehaviour {


	public float wanderRate = 2f, wanderRadius, wanderOffset ;
	Vector3 wanderTarget = new Vector3();

	public float rotateSpeed = 10f;
	public float speed = 10f;
	// Use this for initialization
	public GameObject Player;

	bool doing = false;

	Vector3 playerPosition;
	public float tiltangle = 30f;
	public float smooth = 2f;
	bool followP;

	public float chaseEnergy = 3f;
	float chaseEn;


	//float timeToRecharge = 3f;
	public float rayLength = 10f;
	Vector3 forward;


	Rigidbody rb;
	//public GameObject child;

	public float wanderTime = 5f;
	float timeForWandering;

	public float searchRotateTime = 5f;
	float timeForSearching;

	enum States //our states 
	{
		
		Sleep,
		Attack,
		Searching,
		Wander,
	}

	States currentState = States.Wander; 




	void Start () {
		rb = GetComponent<Rigidbody> ();
		timeForWandering = wanderTime;
		timeForSearching = searchRotateTime;
		chaseEn = chaseEnergy;

	}
	
	// Update is called once per frame
	void Update () {
		/*
		int r = Random.Range (-1, 1);
		float rv = (float) r;

		wanderTime += (Random.value * 5)*r;

		searchRotateTime += (Random.value * 5) *r;

		chaseEnergy  += (Random.value * 5)*r;
    */

		switch(currentState) //pass in the current state
		{

		case States.Wander:
			if (doing == false) {
				doing = true;
				StartCoroutine ("GetPoints");

			}
			timeForSearching = searchRotateTime;


			Wander ();

			break;

			
		case States.Sleep:
			Sleep ();
			break;
		case States.Attack:
			Attack ();
			break;
		case States.Searching:
			timeForWandering = wanderTime;
			Searching ();

			break;

	
		}




		playerPosition = Player.transform.position;
	//this gets the direction this gameobject is pointed in.
	 forward = transform.TransformDirection(Vector3.up);

	



		//}

	 
	}


	void Initialize(){

		currentState = States.Wander;
	}
	void Sleep(){
		if (chaseEn <= 3) {
			chaseEn += Time.deltaTime;
		} else {
			currentState = States.Wander;
		}
		}

	void Attack(){
		
		if (chaseEn > 0) {
			
			Vector3 moveDirection = (GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position).normalized;
			transform.position += moveDirection * speed * Time.deltaTime;
			transform.rotation = Quaternion.FromToRotation (Vector3.up, moveDirection);

			chaseEn -= Time.deltaTime;
		} else {
			currentState = States.Sleep;
		}
	}

	void Searching(){


		if (timeForSearching > 0.0f) {
			
			transform.Rotate (Vector3.back, (rotateSpeed * Time.deltaTime));

			int layerMask = 8 << 8;
			if (Physics.Raycast (transform.position, forward, rayLength, layerMask)) {
				currentState = States.Attack;
			}
			timeForSearching -= Time.deltaTime;
		} else {
			
			currentState = States.Wander;
		}
	}

	void Wander(){



/*

		//float jitterTimeSlice = wanderRate * Time.deltaTime;  // what is this?? 
		// so one new target every second? 

		Vector3 wanderTarget = new Vector3 ();

		Vector3 ToAdd = UnityEngine.Random.insideUnitCircle * jitterTimeSlice;

		wanderTarget += ToAdd;  
		wanderTarget.Normalize ();
		wanderTarget *= wanderRadius;

		Vector3 localTarget = wanderTarget + Vector3.up * wanderOffset;
		Vector3 worldTarget = transform.TransformPoint (localTarget);
		Face (worldTarget);
		rb.AddForce ((worldTarget - transform.position).normalized * speed);
		*/

	
		//wanderTarget = UnityEngine.Random.insideUnitCircle;
		//float jitterTimeSlice = wanderRate * Time.deltaTime;  // returns a new value (float representing seconds) every wanderRate seconds.
		/*
		 //jitterTimeSlice;  // this is to hold the target on the circle infront of the entity, blank here 
		Vector3 centre = child.transform.position;

		wanderTarget *= wanderRadius;  //multiples magnitude of the wanderTarget vector (size from its origin in circle) by wanderRadius;
		//this increases or decreases the angle from the entity to this point 

		Vector3 localTarget = centre + wanderTarget
			; 
		 //This takes the local transform of the object, and makes a point that's wanderOffset amount away in the up direction
		// and adds the random point on in the circle which is wanderRadius big, to it. 


		Vector3 moveDirection = localTarget - transform.position;
		//Face (localTarget);
		//transform.rotation = Quaternion.FromToRotation (Vector3.up, moveDirection);
		//transform.rotation = Quaternion.FromToRotation (Vector3.up, moveDirection);
		rb.AddForce(moveDirection.normalized * speed) ;
	*/

		transform.position += transform.up* speed;


		if (Physics.Raycast (transform.position, forward, rayLength/2)) {  //can't see as far while just wandering around
			currentState = States.Attack;
		}

		timeForWandering -= Time.deltaTime;
	
		Debug.Log ("Wandering");

		if(timeForWandering < 0){
			
		currentState = States.Searching;

	   }
			
	}


	IEnumerator GetPoints(){
		while (doing == true) {
			wanderTarget = UnityEngine.Random.insideUnitCircle;
			//Debug.Log (wanderTarget);
			yield return new WaitForSeconds (wanderRate);
		}
	}

	public void Face(Vector3 faceThis){
		//Vector3 dir = faceThis - transform.position;
		//float rot_z = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		//Align (Quaternion.Euler (0f, 0f, rot_z - 90));
	}



	void OnTriggerEnter (Collider other){
	
		currentState = States.Attack;
	}



}
