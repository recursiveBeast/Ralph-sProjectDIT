using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


	public AudioSource explosion1;
	public AudioSource explosion2;

	void Update () {
		//destroys the bullet after two seconds
		//Destroy (gameObject, 2);
	}

	void OnTriggerEnter(Collider other){
	
		
		if((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "Enemy2" ) || (other.gameObject.tag == "Enemy3" ) || (other.gameObject.tag == "Enemy4"
			|| (other.gameObject.tag == "EnemyType5"))){

			explosion1.Play ();
			GameplayManager.score++;

			other.gameObject.SetActive (false);
			other.transform.position = new Vector3 (-300, 0, 0);


		}
		
	}
}
