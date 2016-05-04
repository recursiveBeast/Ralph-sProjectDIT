using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState 

{
	private readonly StatePatternEnemy enemy;
	private int nextWayPoint;

	public PatrolState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Look ();
		Patrol ();
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			ToAlertState ();
	}

	public void ToPatrolState()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToAlertState()
	{
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState()
	{
		enemy.currentState = enemy.chaseState;
	}

	private void Look()
	{
		RaycastHit hit;
		if (Physics.Raycast (enemy.transform.position, enemy.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;
			ToChaseState();
		}
	}

	void Patrol ()  //Wander
	{
		enemy.sprite.material.color = Color.green;

		float jitterTimeSlice = enemy.wanderRate * Time.deltaTime;  // what is this?? 
		// so one new target every second? 

		Vector3 wanderTarget = new Vector3 ();

		Vector3 ToAdd = UnityEngine.Random.insideUnitCircle * jitterTimeSlice;

		wanderTarget += ToAdd;  
		wanderTarget.Normalize ();
		wanderTarget *= enemy.wanderRadius;

		Vector3 localTarget = wanderTarget + Vector3.up * enemy.wanderOffset;
		Vector3 worldTarget = enemy.transform.TransformPoint (localTarget);


		Vector3 dir = worldTarget - enemy.transform.position;
		float rot_z = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

		Quaternion target =  (Quaternion.Euler (0f, 0f, rot_z - 90));

		enemy.transform.rotation = Quaternion.Slerp (enemy.transform.rotation, target, Time.deltaTime * enemy.rotationSpeed);

		enemy.rb.AddForce ((worldTarget - enemy.transform.position).normalized * enemy.maxSpeed);


	}
}
