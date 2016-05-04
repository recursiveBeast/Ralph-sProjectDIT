using UnityEngine;
using System.Collections;

public class Fire2 : MonoBehaviour {

	public Rigidbody playerRigidBody;

	public GameObject bullet;

	public AudioSource laserSound;

	Vector3 playerSpeed;

	public static bool canFire = true;
	public float bulletVelocity;
	public float shootDelay = 0.2f;
	//Transform tr;
	// Use this for initialization
	public float bulletLife = 1;
		bool canShoot = true;

	public Transform bulletPrefab;

	void Start() {


	}
	
	// Update is called once per framet
	void Update () {
		playerSpeed = playerRigidBody.velocity;

		if (canFire == true) {
			if (((Input.GetAxis ("fireHorizontal") != 0.0f) || (Input.GetAxis ("fireVertical") != 0.0f)) && canShoot) {
				Vector3 shootDirection = new Vector3 (Input.GetAxis ("fireHorizontal"), Input.GetAxis ("fireVertical"), 0).normalized;

				GameObject bulletInstance = Instantiate (bullet, transform.position, Quaternion.LookRotation (shootDirection)) as GameObject;


				Physics.IgnoreCollision (bulletInstance.GetComponent<Collider> (), GetComponent<Collider> ());

				laserSound.Play ();
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
