using UnityEngine;
using System.Collections;

public class Enemy4v4 : MonoBehaviour {


	//int damping = 2;
	//public Transform target;
	Vector3 moveDirection;
	public bool gotDirection = false;

	public float movementPerFrame = 2f;
	public float moveSeconds = 5f;

	public float timer = 0.0f;
	bool canMove = true;
	public float moveDelay = 1f;

	bool a;
	//public float 
	void Update(){


		move ();
		
		if (timer > moveSeconds) {
			// shooting in one direction works, need to get timer working now.
			Reset();
		}
	}

	void FixedUpdate(){
		timer ++;
	
	}

	void move(){



		if ((canMove) && ( gotDirection == false)) {
			moveDirection = (GameObject.FindGameObjectWithTag ("Player").transform.position
		                 - transform.position).normalized;
			gotDirection = true;

		}


		//&& (timer < moveSeconds)
	

		if(gotDirection == true)  {

			//will move in one direction until gotDirection = false again

			transform.position += moveDirection * movementPerFrame * Time.deltaTime;

	 


	}



	
			

	}

	void Reset(){
		canMove = false;
		gotDirection = false;
		timer = 0;
		Invoke ("canTrue", moveDelay);
	}

	void canTrue(){

		canMove = true;
	}
}
