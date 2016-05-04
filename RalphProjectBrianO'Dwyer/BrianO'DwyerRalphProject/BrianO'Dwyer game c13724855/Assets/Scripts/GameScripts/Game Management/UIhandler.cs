using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIhandler : MonoBehaviour {

	// Use this for initialization

//COULD use a struct to group elements for different UIs 
	public Text scoreText;

	float time;

	bool shown = false;

	public AudioSource timesUpMusic;

	//public GameObject leaderboard;
	public GameObject pauseCanvas; // can I address buttons using the canvas gameobject instead of making individual public gameobject containers?
	public GameObject resume;
	public GameObject endGame;
	public GameObject howPlay;


	public Text timeText;

	public Text bigMessage;
	public Text finalScore;
	public bool isPaused = false;

	bool messageShown = false;


	GameplayManager gameM;
	public Text lives;



	void Start(){
		pauseCanvas.SetActive (true);
		gameM = GetComponent<GameplayManager> (); // I could check the status of a bool in the gamemanager script that refers to a gameoject
		//instead thought I'm making the ref here using public game objects
	}

	void Update () {
		
		timeHandle ();


			pauseMenu ();
	
	}


	void timeHandle(){

		time = gameM.timeRemaining;

		lives.text = "Lives: " + gameM.lives;

		//Gets score from score DestroyPlayer class. 
		 //access the static variable "score" from the DestroyPlayer class.
		scoreText.text = "Score: " + GameplayManager.score;
		

		//Debug.Log (time);

		//timeText.text = "Time: " + (timeRemaining -= Time.deltaTime);


		if (messageShown == false){
			//This is to stop the time from continuing to show below zero
			if (time> 0) {

				timeText.text = "Time: " + time;
			} else {
				timeText.text = "Time: " + 0;
			}

		}


		// here messageShown is in case the player is killed after the time is up it won't show two sets of messages one for the time
		//being up and one for the player having been killed.

		//first one here is for the time being up 


		if ((time <= 0) && (messageShown == false) && (shown == false)) {
			timesUpMusic.Play ();
			bigMessage.text = "Time's Up!"; 
			Invoke ("displayScore", 2);
			messageShown = true;
			Invoke ("showLeaderBoard", 4);
		}
		else if ((GameplayManager.playerAlive == false) && (messageShown == false)  && (shown == false)) {
			messageShown = true;
			bigMessage.text = "Game Over!";

			timeText.text = "Time: " + 0;
			Invoke ("displayScore", 2);
			Invoke ("showLeaderBoard", 4);
		}



		// Keeps the clock at zero after the player runs out of lives or when the time gets to zero it stops from going to a minus number
		// the time is set to 0 in the if else statement below but this code inside the if messageShown==false, would reset it to 
		//whatever time is left, so checking for the messageShown bool prevents that
	



	}


				void displayScore (){
		//messageShown = true;
		bigMessage.text = ""; // hides rid of the "Time's up" message
				finalScore.text = "Final Score: " + GameplayManager.score;
			   
			}



	void pauseMenu(){
		if (isPaused == true) {
			
			resume.SetActive (true);
			endGame.SetActive (true);
			howPlay.SetActive (true);

		} else {
			
			resume.SetActive (false);
			endGame.SetActive (false);
			howPlay.SetActive (false);
		}

	}

	void showLeaderBoard(){
		shown = true;
		Debug.Log ("works1");
		SceneManager.LoadScene("ScoresAfter");
		//leaderboard.SetActive (true);
	}


}
