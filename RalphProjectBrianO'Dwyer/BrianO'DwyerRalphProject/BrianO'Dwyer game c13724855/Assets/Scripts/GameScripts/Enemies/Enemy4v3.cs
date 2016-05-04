using UnityEngine;
using System.Collections;

public class Enemy4v3 : MonoBehaviour {

	// Use this for initialization
	public float speed = 1f;
	// inRange;
	
	//	bool inRange = false;
	public float health = 10f;
	bool yesno;
	
	public GameObject player;
	//public float range = 20f;
	public float distance;
	bool move = true;
	public float moveDelay = 2f;
	bool positionGot = false;
	Vector3 moveDirection;
	void Start () {
		

		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		//distance = Vector3.Distance(player.transform.position, transform.position);
		//if (distance < range) {
		//	move = true;
		//}

		for (int i = 0; i <= 5; i++) {
		
			transform.position += moveDirection * speed * Time.deltaTime;

		}





		if(positionGot == false){
			moveDirection = getPosition();
		}
		
		if ((positionGot == true) && (move == true)) {
			
			//transform.position += moveDirection * speed * Time.deltaTime;


			// Have to reset the boolean here otherwise once true it remains true and will always move 
			
			Invoke("cantMove", moveDelay);
		}
		

	
	}

	void cantMove(){
		move = false;
		Invoke ("canMove", moveDelay);
	}

	void canMove(){
		move = true;
		positionGot = false;
	}


	Vector3 getPosition(){
		 return moveDirection = (GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position).normalized;
		//positionGot = true;
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
