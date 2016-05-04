using UnityEngine;
using System.Collections;

public class Enemy4 : MonoBehaviour {

	public float speed = 10f;
	Rigidbody rb;
	bool moved = false;

	public float swapTime = 2f;


	void Start(){
		rb = GetComponent<Rigidbody> ();
	
	}

	void Update () {


		if ((GameplayManager.playerActive == true ) &&  (moved == false )) {
			move ();
		
		}


	}




	void move(){
		

	Vector3 moveDirection = ((GameObject.FindGameObjectWithTag("Player").transform.position) - (transform.position)).normalized;
  	rb.AddForce(moveDirection * speed);

		moved = true;

		Invoke ("swap", 2);


	}

	void swap(){

		moved = false;
	}

}
