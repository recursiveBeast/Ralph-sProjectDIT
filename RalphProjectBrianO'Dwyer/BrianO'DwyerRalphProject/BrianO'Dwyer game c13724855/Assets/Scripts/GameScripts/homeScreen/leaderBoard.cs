﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class leaderBoard : MonoBehaviour {

	// Use this for initialization
	public GameObject mainMenu;
	public GameObject scores;

	bool showScores1 = true;

	public Text text1st;
	public Text text2nd;
	public Text text3rd;

	public Text showName1;
	public Text showName2;
	public Text showName3;

	public Text showScore1;
	public Text showScore2;
	public Text showScore3;

	void Start(){


	}

	void Update(){

		// I was using if (scores.activeSelf == true) but this was causing an error because it was being quit
		// some part way through the body of the if statement by the return to main menu function below which turned
		// off the canvas SetActive(false)

		if (showScores1 == true) {
			text1st.text = "1st";
			text2nd.text = "2nd";
			text3rd.text = "3rd";

			showName1.text = PlayerPrefs.GetString ("name1");
			showName2.text = PlayerPrefs.GetString ("name2");
			showName2.text = PlayerPrefs.GetString ("name3");



			showScore1.text = "" + PlayerPrefs.GetInt ("Score1");
			showScore2.text = "" + PlayerPrefs.GetInt ("Score2");
			showScore3.text = "" + PlayerPrefs.GetInt ("Score3");

		} 

	}

	public void loadTitleScreen(){

		Debug.Log ("clicked");
		SceneManager.LoadScene("Homescreen");
	}





}
