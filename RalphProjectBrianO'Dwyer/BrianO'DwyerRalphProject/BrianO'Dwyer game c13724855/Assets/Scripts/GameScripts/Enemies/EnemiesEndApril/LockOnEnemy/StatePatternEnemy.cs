using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour 
{
	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float sightRange = 20f;

	[HideInInspector] public Rigidbody rb;

	//public float wanderRate, wanderRadius, wanderOffset, maxSpeed, rotationSpeed;

	public float maxSpeed, arriveRadius=0.5f, slowradius = 3f, maxPrediction = 5f, rotationSpeed = 2f, 
	wallAvoidDistance = 3f, distanceToAvoid = 2f, wanderRate, wanderRadius, wanderOffset, wanderOrientation, maxAcceleration ;



	[HideInInspector] public SpriteRenderer sprite;

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public NavMeshAgent navMeshAgent;

	private void Awake()
	{
		chaseState = new ChaseState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);

		sprite = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () 
	{
		currentState = patrolState;
	}

	// Update is called once per frame
	void Update () 
	{
		currentState.UpdateState ();
	}

	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter (other);
	}
}