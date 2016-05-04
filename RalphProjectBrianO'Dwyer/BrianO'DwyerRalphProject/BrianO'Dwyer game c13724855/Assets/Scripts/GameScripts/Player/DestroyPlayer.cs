using UnityEngine;
using System.Collections;


public class DestroyPlayer : MonoBehaviour {

	// This is a script to go on an enemy 
	//This will also destroy the enemy if the enemy is hit 

	public AudioSource dieSound;


	float thisScore;
	public static bool playerDiedAgain = false;

	public static bool showPlayer = true;
	SpriteRenderer playerSprite;
	public static bool lifeTaken = false;
	//public bool istouching = false;
	//public bool seesplayer = false;

	void Update(){
		//if ((GameplayManager.playerActive == true)&& (GameplayManager.playerAlive == true)) {
		//	showPlayer = true;
		//}

		if (showPlayer == true) {

			// this should probably be in the GameplayManager..!
			playerSprite.enabled = true;

		} else {
			playerSprite.enabled = false;
		}
	
	
	}
	void Start(){

		playerSprite = GetComponent<SpriteRenderer> ();

	}



	void OnCollisionEnter(Collision other){


		if((other.gameObject.tag == "Enemy" )||(other.gameObject.tag == "Enemy2" )||(other.gameObject.tag == "Enemy3" )||(other.gameObject.tag == "Enemy4" )){

			dieSound.Play ();
				playerSprite.enabled = false;
			showPlayer = false;


			//this is for communicating with GameplayManager that a life has been taken
			GameplayManager.playerActive = false;

		

		  }

	}


}

