using UnityEngine;
using System.Collections;

public class Enemy5 : MonoBehaviour {

	// Use this for initialization

	//public GameObject bullet;

	/// <summary>
	/// T
	/// 
	/// Create two vectors, based off the enemy 
	/// choose two of them at random and lerp between them at a random rate per frame
	/// if hit a wall reverse all values 
	/// </summary>

	public bool isHitting = false;
	public float speed = 5f;





	// the wonders of programming!!! had "on" instead of "On" cost me half an hour probably..
	void OnCollisionEnter(Collision other){
		
		if (other.gameObject.tag == "LaserBall") {
			isHitting = true;
		
			transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
		}
	}

}
