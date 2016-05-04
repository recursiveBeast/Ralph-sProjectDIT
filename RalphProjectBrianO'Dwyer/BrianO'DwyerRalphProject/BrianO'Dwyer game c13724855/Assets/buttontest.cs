using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttontest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void exitToTitle(){
		SceneManager.LoadScene ("Homescreen");

	}
}
