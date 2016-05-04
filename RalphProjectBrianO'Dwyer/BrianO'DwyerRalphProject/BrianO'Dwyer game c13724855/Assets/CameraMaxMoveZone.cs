using UnityEngine;
using System.Collections;

public class CameraMaxMoveZone : MonoBehaviour {

	// Use this for initialization
	public bool inZone = true;
	GameObject g ;
	Collider c;

		
	

	void Start () {
	//	g = GameObject.Find ("Player");
	//c = g.GetComponent<Collider> ();

	}
	
	// Update is called once per frame
	void Update () {
	   
	}

	void OnTriggerExit(Collider other) {

		if (other.gameObject.name == "Player") {
			inZone = false;
		}
	}
}
