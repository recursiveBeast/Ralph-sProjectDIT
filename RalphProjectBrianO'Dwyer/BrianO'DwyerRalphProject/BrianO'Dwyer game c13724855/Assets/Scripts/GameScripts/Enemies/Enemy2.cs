using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {


	// DOES this enemy type make sense?? 
	// it kills you by touching you 
	// but you're making it run away when you move towards it ..? 
	// Ok so it would prefer to live than to kill you
	//So having the player have a field of vision could be a definite advantage.. what advantage is there to it not having it? 
	//Try make this basic version first see how it goes!. 

	// Use this for initialization
	//distance between enemy and player

	public float movePerSecond= 5f;
	public float homeDistance; 
	Vector3 rate;

	float distance; // magnitude/distance between Enemy3 and Player
	public GameObject player;
	//Need a rate of appraoch 
	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		rate = rb.velocity; // current speed of enemy3

		//distance between enemy3 and player


		//so want to determine if the distance is decreasing faster than it would if Enemy3 was moving towards a stationary Player
		// this is the magnitude .. 
		// if it is then by how much? 
		//if it's not then make Enemy3 move toward player using its transform

		//movement is based on two things: 
		//First, based on Enemy3's current speed, magnitude should be decreasing by x amount - so x amount has to be a function of speed 
		//Second it's based on whether or not the player is moving towards Enemy3
		// These are interlinked.
		//
		// So the first one is determined, and if the distance is decreasing faster than that Enemy3 will move away from the player
		//
		// Have to also account for Enemy3 being stationary and the player moving towards it. 
		// also can't have it be the same distance away from the player all the time 
		// Enemy3 should have a "wake up" zone of about 10 or not? 
		//

		// OK 
		// so if distance is decreasing faster than speed, move in opposite direction. Simples!. 
		// amount over time = speed or distance over time, 
		// how determine rate of decreasing distance? 
		//Speed is distance/time 





		//if it is, then make Enemy3 move the opposite direction


		// IF you can answer how to make it move by x units per second 
		//Speed = distance* time.deltatime  so distance per second 

		//Get a unit size for how big a unit the distance between the two is changing each second
		// compare that unit size with the size you've set for Enemy3's movePerSecond
		// if it's smaller or equal then move towards
		// if it's larger then change direction 

		// Use linear interpolation 


	}
	
	// Update is called once per frame
	void Update () {
		//check the distance between them every frame
		//check the speed of decrease of distance between them 
		distance = Vector3.Distance (gameObject.transform.position, player.transform.position);
		Debug.Log (distance);

		homeDistance = distance * Time.deltaTime;

		 //transform.position += moveDirection * movePerSecond * Time.deltaTime;

	//	if (movePerSecond > closingMove ) {
		//	Vector3 moveDirection = (GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position).normalized;
		//	transform.position += moveDirection * movePerSecond * Time.deltaTime;
		
	//	} else {
	//	/	Vector3 moveDirection = (GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position).normalized;
		///	transform.position -= moveDirection * movePerSecond * Time.deltaTime;
		//
		//}

	
	}
}
