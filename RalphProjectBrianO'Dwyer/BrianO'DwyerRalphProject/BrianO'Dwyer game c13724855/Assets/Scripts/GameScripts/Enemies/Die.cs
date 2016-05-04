using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {
	// This is a script to go on an enemy 
	//This will also destroy the enemy if the enemy is hit 
	
	float thisScore;
	public GameObject player;
	public static bool playerAlive = true;
	public bool istouching = false;
	public bool seesplayer = false;
	void Start(){
		
		
	}
	void OnCollisionEnter(Collision other){
		istouching = true;
		
		if(other.gameObject.tag == "Player"){
			seesplayer = true;
			player.SetActive (false);
			playerAlive = false;
			
		}
		if (other.gameObject.tag == "LaserBall") {
			
			//			GameManger.score++;
			Destroy (gameObject);
			
		}
	}
}
