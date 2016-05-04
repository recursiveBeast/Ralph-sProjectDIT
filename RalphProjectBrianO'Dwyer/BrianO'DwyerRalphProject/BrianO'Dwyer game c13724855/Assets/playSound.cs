using UnityEngine;
using System.Collections;

public class playSound : MonoBehaviour {


	AudioSource s;

	void Start () {
		s = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void play(){
		s.Play ();

	}
}
