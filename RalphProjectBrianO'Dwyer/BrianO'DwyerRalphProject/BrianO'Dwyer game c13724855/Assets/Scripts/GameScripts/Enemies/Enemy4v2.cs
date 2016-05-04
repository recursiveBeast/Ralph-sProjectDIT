using UnityEngine;
using System.Collections;

public class Enemy4v2 : MonoBehaviour {

	
	//public GameObject bullet;
   public float bulletVelocity = 10f;
	public float shootDelay = 0.2f;
	//Transform tr;
	// Use this for initialization
//	public float bulletLife = 1;
	bool canShoot = true;
	Rigidbody rb;

	void Start () {
	
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per framet
	void Update () {
		
		if (canShoot)
		{
			Vector3 shootDirection =  ((GameObject.FindGameObjectWithTag("Player").transform.position) - (transform.position)).normalized;

			rb.AddForce (shootDirection * bulletVelocity, ForceMode.VelocityChange);
			canShoot = false;
			Invoke ("ShootDelay", shootDelay);
			

		}
		
		
	}
	
	void ShootDelay()
	{
		canShoot = true;
		
	}
}
