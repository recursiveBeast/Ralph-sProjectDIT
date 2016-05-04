using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameplayManager : MonoBehaviour {

	public int lives = 5;
	public static int score;
	public static bool playerActive = true;

	public bool destroyEnemiesAll = true;

	bool playMusic = true;
	bool playSoundEffects = true;
	public bool resetAllScores = false;

	public AudioSource mainMusic;


	public AudioSource gameOverAudio;
	public AudioSource gameOverAudio1;

	public GameObject audioManager;
	public audioManagerMain audioManagerScript;

	public AudioSource enemyWaveAlert;
	public AudioSource respawnSound;

	public AudioSource pauseSound;



	bool scoreDone = false;

	//bool s = true; // spawn or not

	public float timeRemaining = 120f; 

	public float timeTilRespawn = 10f;
	public GameObject Player;

	public GameObject centre1;

	public GameObject enemy1;
	[HideInInspector] public  List<GameObject> enemy1List;

	public GameObject enemy2;
	[HideInInspector] public List<GameObject> enemy2List;

	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;

	int half;
	int otherhalf;

	public GameObject c1;
	public GameObject  c2;
	public GameObject  c3;
	public GameObject  c4;


	UIhandler UIstuff;


    Transform centre;
	public Transform player;
	Vector3 position;
	public static bool playerAlive = true;
	// Use this for initialization



	void Start () {
		//centre = centre1.GetComponent<Transform> ();
		if (playMusic == true) {
			mainMusic.Play ();
		}
		UIstuff = GetComponent<UIhandler> ();

		Debug.Log (timeTilRespawn);
		Spawner ();
	
		position = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	
		resetScores ();

	
	
		Pause ();

		timeHandler ();

	}





	/// dieRespawn and related methods handle the player losing lives, clearing the board of enemies, respawning and running out of lives. 


	void dieRespawn ()
	{


		//if player gets hit, the sprite renderer turns off, then this code below deletes all the enemies.
		// playerActive is just a bool it's not whether the player is active in hierarchy or not, the player will be invisible if the value is false though
		//if (diedRespawned == false) {

		PlayerController.canMove = false;
		fire1_2.canFire = false;
		CameraControllerFlocking.playerDead = true;

		playerActive = true;

			if (lives  == 1) {
			lives = 0;
			gameOverAudio1.Play ();
			gameOver ();

			}
		else

			if (lives > 1) {
		
				//DestroyPlayer.showPlayer = false;
				//1st check if lives are greater than 0, if they are take away a life
				// if not then run gameover
				//2nd destroy all enemies  

				// Now Invoke newLife method - 
				//3rd send back the message to DestroyPlayer to turn back on the sprite
				//4th send back the message to make lifeTaken in DestroyPlayer "false" again 
				//5th repawn more enemies

				lives--;

			Debug.Log (lives);

				GameObject[] gameObjects;
				gameObjects = GameObject.FindGameObjectsWithTag ("Enemy");
		
				for (int i = 0; i < gameObjects.Length; i++) {
					Destroy (gameObjects [i]);
				}

			



				Invoke ("newLife", timeTilRespawn);
				//playerActive = true; //funny bug if you leave this out

			
			}

			}

		//}

	




	void newLife(){



		Player.transform.position = new Vector3(0,0,0);
		// how get cam to smooth back to position?

		respawnSound.Play();
		DestroyPlayer.showPlayer = true;
		CameraController.playerDead = false;
		PlayerController.canMove = true;
		fire1_2.canFire = true;
		//DestroyPlayer.lifeTaken = false;


		SpawnerInvoke ();

		//diedRespawned = true;;
	}
	

	void gameOver(){
		scoreHandler ();
		playSoundEffects = false;

		mainMusic.Stop ();

		if (gameOverAudio.isPlaying) {
			

		} else {
			//gameOverAudio.Play ();
		}

		//Player.SetActive(false); // remember that this is a method and you have to pass either true or false to it as an argument
		DestroyPlayer.showPlayer = true;

		playerAlive = false;
		//UIhandler receives PlayerAlive because it checks for it using GameManager.PlayerAlive
	    //Send other messages here to handle screen switching?? 
		if (destroyEnemiesAll == true) {
			destroyEnemies ();
		}

	}

	void destroyEnemies(){


		GameObject[] gameObjects;

		if (GameObject.FindGameObjectsWithTag("Enemy") != null) {
			gameObjects = GameObject.FindGameObjectsWithTag ("Enemy");
		
		for (int i = 0; i < gameObjects.Length; i++) {
			Destroy (gameObjects [i]);
		}
		

		}





	}
	////////////
	/// 
	/// 
	/// 
	/// 
	void timeHandler(){

		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0) {
			Debug.Log ("Works");
			//gameOverAudio.Play ();
			gameOver();
		}

		if (playerActive == false) {

			dieRespawn ();
		}
	}


	void scoreHandler(){
		if (scoreDone == false) {
			int oldScore1 = PlayerPrefs.GetInt ("Score1");
			int oldScore2 = PlayerPrefs.GetInt ("Score2");
			int oldScore3 = PlayerPrefs.GetInt ("Score3");


			if (score > oldScore1) {


				PlayerPrefs.SetInt ("Score1", score);
				PlayerPrefs.SetInt ("Score2", oldScore1);
				PlayerPrefs.SetInt ("Score3", oldScore2);

			} else if ((score <= oldScore1) && (score > oldScore2) && (score > oldScore3)) {
				PlayerPrefs.SetInt ("Score2", score);

			} else if ((score <= oldScore2) && (score > oldScore3)) {
				PlayerPrefs.SetInt ("Score3", score);

			}
			scoreDone = true;	
		}
		//Debug.Log(PlayerPrefs.GetInt("Score"));
	}

	void resetScores(){
		if (resetAllScores == true) {
			PlayerPrefs.SetInt ("Score1", 0);
			PlayerPrefs.SetInt ("Score2", 0);
			PlayerPrefs.SetInt ("Score3", 0);
		}
	}

	/////////////////////////////////////////////

	////Here goes UI and scene change stuff:


	void Pause(){
		if (Input.GetKeyDown ("p") == true) {
			pauseSound.Play ();
			Time.timeScale = 0;

			UIstuff.isPaused = true;
		}
	
	}

	public void Resume(){
		UIstuff.isPaused = false;
		Time.timeScale = 1;
		pauseSound.Play ();
	}
		
	public void goToMainMenu(){


		SceneManager.LoadScene("Homescreen");
	}

	//////////////////////////////////

/// <summary>
///UNDER HERE ARE METHODS FOR CREATING ENEMY WAVES
/// 
/// </summary>
	/// 
	/// //INVOKE REPEATING  !!!!!  Coroutines 

	void SpawnerInvoke(){
		
			Spawner ();

		/*//if (timeRemaining < 180) {
		//	Spawner ();
		//}

		//if (timeRemaining < 165) {
			//Spawner ();
		//}
		//if (timeRemaining < 150) {
		//	Spawner ();
		//}
		if (timeRemaining < 130) {
			Spawner ();
		}
		//if (timeRemaining < 110) {
		//	Spawner ();
		//}
		if (timeRemaining < 90) {
			Spawner ();
		}
		//if (timeRemaining < 70) {
		//	Spawner ();
		//}
		if (timeRemaining < 55) {
			Spawner ();
		}
		//if (timeRemaining < 45) {
		//	Spawner ();
		//}
		if (timeRemaining <  35 ) {
			Spawner ();
		}
		//if (timeRemaining < 25 ){
		//	Spawner ();
		//}
			if (timeRemaining < 17) {
				Spawner ();
			}
		if (timeRemaining < 12) {
			Spawner ();
		}
*/
	}


	void Spawner(){

	


		enemy1wave ();
		Invoke ("startRoutine1", 4);

		//enemy2wave ();
		//Invoke ("ins1_1", 1);

		//Invoke("ins1_2",3 );
		//Invoke ("ins1_3", 1);
		//Invoke ("ins1_4", 3);

	
	 //Invoke ("ins3_1", 30);
	//	Invoke ("ins3_2", 30);

		//Invoke ("ins1_1", 35);
		//Invoke ("ins1_1", 36);
		//
		//Invoke ("ins1_1", 1);
	//	Invoke ("ins1_2", 1);

	//	Invoke ("ins4_1", 6);
		//Invoke ("ins4_2", 10);

		//Invoke ("ins1_1", 3);
		//Invoke ("ins1_1", 1);
		//Invoke ("ins1_1", 1);
		//Invoke ("ins1_1", 1);

		//Invoke ("ins4_1", 10);
	//	Invoke ("ins4_2", 12);

	
	}



			void startRoutine1(){
		setActive1_1 ();
			}

	void enemy1wave(){
		StartCoroutine ("ins1_1");
		//StartCoroutine ("ins1_2");
		//StartCoroutine ("ins1_3");
		//StartCoroutine ("ins1_4");

	
	}

	void enemy2wave(){


		if (playSoundEffects == true) {
			enemyWaveAlert.Play ();
		}

		StartCoroutine ("ins2_1");


	
	}



	IEnumerator ins2_1(){

		for (float i = 0; i < 100; i++) {
			Vector3 a = new Vector3 (i-1000, 0, 0);

			enemy2List.Add((GameObject) Instantiate (enemy2, c1.transform.position - a, Quaternion.identity));

			yield return new WaitForSeconds(0.3f);
		}
		playSoundEffects = false;

	}


	IEnumerator ins1_1(){
		
		for (int i = 0; i < 40; i++) {
			Vector3 a = new Vector3 (i-1000, 0, 0);

			enemy1List.Add((GameObject) Instantiate (enemy1, c1.transform.position - a, Quaternion.identity));
			enemy1List [i].SetActive (false);

			yield return new WaitForSeconds(0.1f);
		}

			}





	void setActive1_1(){
		
		
		if (playSoundEffects == true) {
			enemyWaveAlert.Play ();
		}

		//Vector3 a = new Vector3 (15, 0, 0);



		if (enemy1List.Count % 2 == 0) {
			half = enemy1List.Count / 2;
			otherhalf = half;
		} else {
		
			half = enemy1List.Count - 1;
			otherhalf = half + 1;
		}

		for (int i = 0; i < half; i++) {

			// problem using co routines and lists..
			//	Vector3 newpos = new Vector3 (c1.transform.position.x,0,0);
			enemy1List [i].transform.position = c1.transform.position;
		}
		for (int i = 0; i < otherhalf; i++) {

			// problem using co routines and lists..
			//Vector3 newpos = new Vector3 (c2.transform.position.x);
			enemy1List[i].transform.position =c2.transform.position;
		}





		StartCoroutine ("a");

	}


	IEnumerator a(){

		// have to make this do it on every second one.. 

		for (int i = 0; i < enemy1List.Count; i++) {
			
			enemy1List [i].SetActive (true);

			yield return new WaitForSeconds(0.4f);
		}

	}



	IEnumerator ins1_2(){

		for (int i = 0; i < 10; i++) {
			Instantiate (enemy1, c2.transform.position, Quaternion.identity);

			yield return new WaitForSeconds(0.5f);
		}

	}


	IEnumerator ins1_3(){

		for (int i = 0; i < 10; i++) {
			Instantiate (enemy1, c3.transform.position, Quaternion.identity);

			yield return new WaitForSeconds(0.5f);
		}

	}


	IEnumerator ins1_4(){

		for (int i = 0; i < 10; i++) {
			Instantiate (enemy1, c4.transform.position, Quaternion.identity);

			yield return new WaitForSeconds(0.5f);
		}

	}


}
