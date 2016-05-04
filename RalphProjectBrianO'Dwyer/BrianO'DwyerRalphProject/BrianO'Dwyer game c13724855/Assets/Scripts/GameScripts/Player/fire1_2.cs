using UnityEngine;
using System.Collections;

public class fire1_2 : MonoBehaviour {

	Rigidbody playerRigidBody;

	public GameObject bullet;

	public AudioSource laserSound;

	Vector3 playerSpeed;

	public static bool canFire = true;
	public float bulletVelocity = 50;
	public float shootDelay = 0.05f;
	//Transform tr;
	// Use this for initialization
	public float bulletLife = 1;
	bool canShoot = true;

	public Transform laserGun;

	//Vector3 
	void Start() {

		playerRigidBody = GetComponent<Rigidbody> ();
	}

	// Update is called once per framet
	void Update () {
		playerSpeed = playerRigidBody.velocity; 

		if (canFire == true) {
			if (Input.GetButton("Fire1") && canShoot) {
				Vector3 shootDirection = transform.up;

				GameObject bulletInstance = Instantiate (bullet, playerRigidBody.position + new Vector3(0,1,0), Quaternion.LookRotation (shootDirection)) as GameObject;
			
				bulletInstance.transform.rotation = Quaternion.FromToRotation (Vector3.up, shootDirection );

				Physics.IgnoreCollision (bulletInstance.GetComponent<Collider> (), GetComponent<Collider> ());
				if(laserSound != null){
				laserSound.Play ();
				}
				bulletInstance.GetComponent<Rigidbody> ().AddForce ((shootDirection * bulletVelocity)+ playerSpeed, ForceMode.VelocityChange);



				canShoot = false;
				Invoke ("ShootDelay", shootDelay);

				Destroy (bulletInstance, bulletLife);
			}
		}

	}

	void ShootDelay()
	{
		canShoot = true;

	}
}
