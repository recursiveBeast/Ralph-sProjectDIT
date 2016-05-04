using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public float speed = 1f;


	void Update () {

		//this could be wrong coz messed it up when making flocking demo!
		if (GameplayManager.playerActive == true) {
			Vector3 moveDirection = (GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position).normalized;
			transform.position += moveDirection * speed * Time.deltaTime;
		}
	}
}
   
