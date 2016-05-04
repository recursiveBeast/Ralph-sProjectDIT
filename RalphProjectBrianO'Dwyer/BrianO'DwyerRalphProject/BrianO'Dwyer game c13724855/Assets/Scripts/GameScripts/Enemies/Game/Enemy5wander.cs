using UnityEngine;
using System.Collections;

public class Enemy5wander : MonoBehaviour {

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

			float x = Random.value *5;
			float y = Random.value * 5;
			float sign = Random.value;

			if(sign < 0.5){
				x *= -1;
				y *= -1;

			}

			moveDirection = new Vector3(x,y,0);
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
