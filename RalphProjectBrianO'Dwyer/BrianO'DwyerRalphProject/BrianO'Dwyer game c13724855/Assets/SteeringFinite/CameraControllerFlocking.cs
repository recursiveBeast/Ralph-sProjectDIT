using UnityEngine;
using System.Collections;

public class CameraControllerFlocking : MonoBehaviour {

	//Camera has two parts
	// 1: A deadzone, 
	// A collidor trigger box around player that player can move inside
	// if the player touches the trigger the camera will start to follow the player
	
	//2: Camera follow
	// Follows the player as long as they are moving above a certain speed which is based on 
	// IsMoving being true or false

	public Vector3 cameraMax;
	public float cameraMin = 72f;
	Vector3 centre;

	float startingPosition; //the position the camera starts at
	public float distanceWillTravel; // how far you will allow it to travel from its original distance
	 // this means though that the camera will move in a circle..

	public GameObject player; 
	// space for a reference to the player game object
	  // - must drop in gameobject in inspector.


	public static bool playerDead = false;

	private Vector3 offset;  
	// this is a space for a vector that is to be the distance 
	//- between the camera and the player 



    
	// need a ref to CollidorFollowPlayer
	public GameObject deadZone;  // this is deadzone game object - the gameobject with collidor
	// that the player is inside.

	CollFollowPlayer collScript ; // this is the script component of that game object
	// it references the collidor by being attached to the same game object.

	Camera cam;

	bool cameraSet = false;

	void Start () {
		cam = GetComponent<Camera> ();
		cameraMax = new Vector3(0,10, -250);
		centre = new Vector3 (0, 0, 0);
	
	}


	void LateUpdate () {
		//Camera updates go in LateUpdate

		if (playerDead == true) {
			//if player dies this lerps between cameras position and centre,
			// I have it in update as to happen before the rest of the stuff is reset
			Vector3 result = Vector3.Lerp (transform.position, centre + offset, 0.1f);

			transform.position = result;

		}else
		if (playerDead == false) {
			if (cameraSet == false) {
				offset = calculateOffset ();
		
				transform.position = player.transform.position + offset;
				cameraSet = true;
			}
		}
		deadZoneFollow ();


	}

	void Update(){
		
	}

	Vector3 calculateOffset(){
		// This works but it only maintains the relationship between the player object and 
		// camera as set initally set in the inspector, it won't make the camera be perpendicular
		// to the player. 
		
		return offset = transform.position - player.transform.position;
	
	}

	void deadZoneFollow(){
		//playerPosition = player.transform.position; 
	
		collScript = deadZone.GetComponent<CollFollowPlayer> ();
		followPlayer ();


		
		// This sets the camera to follow the player 
		
	}

	void followPlayer(){
		// The camera will follow the player until it is a certain distance away from its original centre.






		//This function first addresses the boolean inBox which if true means that the player
		// is still in the DeadZone and if false it means that they are out of it.
		// If the they are not in the box OR they are moving, it lineraly interpolates 
		// between the player's position and the camera's position and moves the camera 
		// by the proportion set, with each update. 
	
		if (collScript.zoneActive == false) {

			Vector3 playerPlace = new Vector3();
			playerPlace = player.transform.position;

			//Vector3 from = new Vector3 (1f, 2f, 3f);
			//Vector3 to = new Vector3 (5f, 6f, 7f);
			
			// Here result = (4, 5, 6)
			if(cam.transform.position.z < cameraMax.z){
				transform.position += new Vector3(0,0,1);
			}

			Vector3 result = Vector3.Lerp (transform.position, player.transform.position + offset, 0.1f);

			transform.position = result;

		}
			}




}
