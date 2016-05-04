using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// This class controls the movement of the player.
	public bool inZone = true;
	public static bool canMove = true;

	Rigidbody rb;//rigidbody of the player gameobject 

	public float speed; // variable on inspector to fine tune speed of player

	public bool isMoving;// Bool to set for when to reset the collidor trigger's position to that of the player's.
	// why need public - collidor follow

	public float isMovingFloor = 5;
	// Float that you can set in the inspector to determine how slow the player needs to be moving
	// to trigger isMoving to false. At 0 the player has to be dead still, so the effect of having 
	// a deadzone will rarely be seen, so it is better to set this at a higher value. 

	//public static  Vector3 moveDirection;

	void Start () {
		rb = GetComponent<Rigidbody>(); 

	}

	void FixedUpdate () {
		if (canMove == true) {
			move ();
			outputIfMoving ();
		}
	
	}



	void move(){



		Vector3 moveDirection = new Vector3 (Input.GetAxis ("Horizontal"),Input.GetAxis("Vertical"),0);

		Vector3 strafeDirection = new Vector3 (Input.GetAxis ("Horizontal"),Input.GetAxis("Vertical"),0);
		//transform.LookAt (moveDirection);
		//float angle = Mathf.Atan2(moveDirection.y,moveDirection.x)* Mathf.Rad2Deg;
		//transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		//Vector3 diff = Camera.main.sc

		//transform.position += moveDirection * speed * 2 * Time.deltaTime;
	if ((Mathf.Abs (moveDirection.x) > 0.0f) || (Mathf.Abs (moveDirection.y) > 0.0f)) {
			transform.rotation = Quaternion.FromToRotation (Vector3.up, moveDirection);

			// this isn't good enough 
			// can be improved later.. 
		}
		rb.AddForce (moveDirection*speed);

		//Another option is to have the sprite rotate towards the firing direction.
		// Another option is to make it single stick and only be able to fire in direction of movement
		// Could have boost function to fly accross screen

		// Could also have dif weapon types/ bombs that radiate bullets - which would make use of the twin stick functionality

		//Could make it slerp , need to convert from Vector3 to Quaternion
		//transform.rotation = Quaternion.Slerp(transform.rotation, moveDirection, Time.deltaTime * 2.0f);




		//transform.Rotate(new Vector3(1.0f,0,0));
		//moveDirection = Vector3.Normalize(moveDirection);  Dont need this as the input axis are already normalised


		//Vector2 motionDirection = rb.velocity.normalized;
		//transform.rotation = Quaternion.LookRotation(moveDirection, new Vector3(0,0,1));
		//transform.position += moveDirection * speed * 2 * Time.deltaTime;
	}

	void outputIfMoving (){
		//This function examines the x and y axis of the velocity vector3 of the rigidbody 
		 //  attached to the player, which is referred to in rb.
		// It takes the absolute value of their numbers, and checks if either of them is greater
		// than the number put in for isMovingFloor, and if so it makes isMoving true.

		float x = rb.velocity.x;
		float y = rb.velocity.y;

		if ((Mathf.Abs(x) > isMovingFloor) || ( Mathf.Abs(y) > isMovingFloor)) {
			isMoving = true;
			
		} else {
			isMoving = false; 
		}

		//Debug.Log (isMoving);


	}

	void OnTriggerExit(Collider other) {

		if (other.gameObject.name == "CameraMoveZone") {
			inZone = false;
		}
	}
}
