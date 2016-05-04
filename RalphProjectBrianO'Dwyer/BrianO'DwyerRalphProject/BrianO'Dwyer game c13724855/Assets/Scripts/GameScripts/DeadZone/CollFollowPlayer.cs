using UnityEngine;
using System.Collections;

public class CollFollowPlayer : MonoBehaviour {
	 
	// This is a script to be attached to the empty game object called DeadZone that holds 
	// a trigger collidor box around the player to act as a zone that if the player moves within, 
	// the camera won't follow the player.

	//What does this script do? 
	//Gets the deadzone collidor trigger to reset to the position of the player when the player
	// has moved out of the trigger area AND
	// is moving less than a certain speed, as denoted by isMoving being true or false.
	 
	//isMoving is a public variable of the player gameobject.

	//
	// This script starts by positioning the collidor at the same position as that of the Player.
	// It checks if the Player's variable isMoving is true or false.
	// If isMoving is false AND player is outside the collidor trigger 
	// it updates the collidor's position to that of the player.


		
	public GameObject player; // A space to hold the player gameobject that the collidor is to
	// follow. Slot in the gameobject in the inspector. 

	PlayerController playerScript;//this is a variable to store a reference 
	/// to the Player object's PlayerController script.???

	 
	public bool inBox;
	public bool zoneActive = true;

	void OnTriggerEnter () {
		inBox = true;
		//Debug.Log ("IN BOX");
	}
	
	void OnTriggerExit (Collider other){
		
		inBox = false;
		//Debug.Log ("OUT BOX");
	}

	void Start () {
		//this gets the PlayerController script component from the Player gameobject
		// and stores it in PC1 
		playerScript = player.GetComponent<PlayerController>();


		//This starts the collidor at the same position as the player
		// It runs once when the game starts
		transform.position = player.transform.position;
	}


	void Update() {

		//this checks the isMoving boolean variable of the Player gameobject stored in PC1 
		if ((playerScript.isMoving == true) && (inBox == false)) {
			zoneActive = false;


		}
		
		if (playerScript.isMoving == false) {
			zoneActive = true;
		

			if (inBox == false) {

				// if the boolean value returns false it sets the transform of this collidor (because
				//this script is a component of the collidor in question) to be the same as the transform
				// of the player 
				transform.position = player.transform.position;
			}
		}
	}



}
