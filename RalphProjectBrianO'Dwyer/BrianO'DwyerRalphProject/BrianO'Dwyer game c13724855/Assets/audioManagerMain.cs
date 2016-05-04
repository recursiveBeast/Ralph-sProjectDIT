using UnityEngine;
using System.Collections;

public class audioManagerMain : MonoBehaviour {


	public AudioSource enemyWaveAlert;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void playSound(){
		enemyWaveAlert.Play ();

	}
}
