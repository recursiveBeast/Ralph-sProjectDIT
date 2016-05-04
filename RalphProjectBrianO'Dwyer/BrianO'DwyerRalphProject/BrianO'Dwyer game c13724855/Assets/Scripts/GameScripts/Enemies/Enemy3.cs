using UnityEngine;
using System.Collections;

public class Enemy3 : MonoBehaviour {
	// Use this for initialization
	public float speed = 1f;
	// inRange;

//	bool inRange = false;
	public float health = 10f;
	bool yesno;

	public GameObject player;
	public float range = 20f;
	public float distance;
	bool move;


	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		// why is it shooting off at start??
		distance = Vector3.Distance(player.transform.position, transform.position);
		if (distance < range) {
			move = true;
		}

		if (move == true) {
			
			Vector3 moveDirection = (GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position).normalized;
			transform.position += moveDirection * speed * Time.deltaTime;

			// Have to reset the boolean here otherwise once true it remains true and will always move 
			move = false;
		}


	}

	void followPlayer(){



	}

	void OnTriggerEnter(Collider other){
		

		if (other.tag == "LaserBall") {
			
			GameplayManager.score++;
			health--;
			if(health <= 0){
			Destroy (gameObject);
			}
			
		}

		//void sight(){



		}
}
