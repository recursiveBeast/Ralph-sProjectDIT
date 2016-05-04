using UnityEngine;
using System.Collections;

public class AlertState : IEnemyState 

{
	private readonly StatePatternEnemy enemy;
	private float searchTimer;

	public AlertState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Look ();
		Search ();
	}

	public void OnTriggerEnter (Collider other)
	{

	}

	public void ToPatrolState()
	{
		enemy.currentState = enemy.patrolState;
		searchTimer = 0f;
	}

	public void ToAlertState()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToChaseState()
	{
		enemy.currentState = enemy.chaseState;
		searchTimer = 0f;
	}

	private void Look()
	{
		RaycastHit hit;
		if (Physics.Raycast (enemy.transform.position, enemy.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;
			ToChaseState();
		}
	}

	private void Search()
	{
		enemy.sprite.material.color = Color.yellow;


	}
}