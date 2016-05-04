using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flocking : MonoBehaviour {

	//Mod this so that it uses transform instead of rigidbody



	public float speed = 1f;
	public float alignmentDistance = 20f;

	Vector3 a = new Vector3(0,0,0);
	Vector3 c = new Vector3(0,0,0);
	Vector3 s = new Vector3(0,0,0);
	Vector3 pl = new Vector3(0,0,0);

	Vector3 xMove = new Vector3(0,0,0);
	Vector3 yMove = new Vector3 (0,0,0);
	Vector3 moveDirection = new Vector3(0,0,0);

	public GameObject gm;
	[HideInInspector] public GameplayManager gpm;

	int neighbourCount = 0;
	Rigidbody rb;
	Rigidbody myRb;

	//public GameObject gm;
	[HideInInspector] public  List<GameObject> enemy1List;

	//public GameObject gM;
	//public GameplayManager gpm;

	void Start(){
		myRb = GetComponent<Rigidbody> ();
		//gpm = gm.GetComponent<SpawnManager> ();

		//for(int i = 0; i < gpm.enemy1List.Count; i++){
		//enemy1List = gpm.enemy1List;
		//}
	}
	void Update () {

		a = computeAlignment (a);
		c = computeCohesion (c);
		s = computeSeparation (s);
		pl = computePlayerLocation ();


		xMove.x += a.x + c.x + s.x;
		yMove.y += a.y + c.y + s.y;
		moveDirection = new Vector3 (xMove.x, yMove.y,0);
		//this could be wrong coz messed it up when making flocking demo!
		if (GameplayManager.playerActive == true) {

		
			moveDirection.x += pl.x;
			moveDirection.y += pl.y;


			move (moveDirection);
		} else {
			move (moveDirection);
		
		}
	}

	Vector3 computeAlignment(Vector3 p){
	
		foreach (GameObject e in enemy1List) {
			if (e != this) {
				rb = e.GetComponent<Rigidbody> ();
				if ((this.transform.position - e.transform.position).magnitude < alignmentDistance) {
					p.x += rb.velocity.x;
					p.y += rb.velocity.y;
					neighbourCount++;

				}
			
			}
				
		}

		p.x /= neighbourCount;
		p.y /= neighbourCount;
		p.Normalize ();
		return p;

	}


	Vector3 computeCohesion (Vector3 cc){

		foreach (GameObject e in enemy1List) {
			if (e != this) {
				rb = e.GetComponent<Rigidbody> ();
				if ((this.transform.position - e.transform.position).magnitude < alignmentDistance) {
					cc.x += e.transform.position.x;
					cc.y += e.transform.position.y;
					neighbourCount++;

				}

			}

		}

		cc.x /= neighbourCount;
		cc.y /= neighbourCount;
		Vector3 v = new Vector3 (cc.x - this.transform.position.x, cc.y - this.transform.position.y);
			v.Normalize ();
		return v;


	}

	Vector3 computeSeparation (Vector3 ss){
		foreach (GameObject e in enemy1List) {
			if (e != this) {
				rb = e.GetComponent<Rigidbody> ();
				if ((this.transform.position - e.transform.position).magnitude < alignmentDistance) {
					ss.x += e.transform.position.x - this.transform.position.x;
					ss.y += e.transform.position.y - this.transform.position.y;
					neighbourCount++;

				}

			}

		}

		ss.x /= neighbourCount;
		ss.y /= neighbourCount;

		//Vector3 v = new Vector3 (ss.x - this.transform.position.x, ss.y - this.transform.position.y);

		ss.x *= -1;
		ss.y *= -1;

		ss.Normalize ();
		return ss;

	}

	Vector3 computePlayerLocation(){
		Vector3 location = (GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position).normalized;
		return location;
	}

	void move(Vector3 mD){
		
		mD = mD.normalized;
		transform.position += mD* speed * Time.deltaTime;
	}
}
