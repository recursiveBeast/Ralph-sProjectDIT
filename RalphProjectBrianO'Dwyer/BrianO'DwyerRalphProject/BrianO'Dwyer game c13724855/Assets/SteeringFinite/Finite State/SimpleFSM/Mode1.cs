using UnityEngine;
using System.Collections;

public class  Mode1 : MonoBehaviour {

	// Use this for initialization
	// Instantiate a load of Agents 
	// For each tagged as boid set the values on the script to produce a good wander
	//
	GameObject [] boids;
	SteeringBehaviours steeringScript;
	public enum boidState {Idle, Seek, Flee, Arrive, Persue, Align, Face, Wander}
	public boidState steerState;

	void Start () {

		steerState = boidState.Idle;
		boids = GameObject.FindGameObjectsWithTag ("Boid");
	

	}
	

	void Update () {
		
		checkState ();
			
	}

		void checkState(){
		switch (steerState) {

		case boidState.Idle:
			for (int i = 0; i < boids.Length; i++) {


				steeringScript = boids [i].GetComponent<SteeringBehaviours> ();
				steeringScript.aiState = SteeringBehaviours.AgentState.Seek;

			}
			break;


		case boidState.Seek:
			for (int i = 0; i < boids.Length; i++) {


				steeringScript = boids [i].GetComponent<SteeringBehaviours> ();
				steeringScript.aiState = SteeringBehaviours.AgentState.Seek;

			}
			break;

		case boidState.Flee:
			for (int i = 0; i < boids.Length; i++) {


				steeringScript = boids [i].GetComponent<SteeringBehaviours> ();
				steeringScript.aiState = SteeringBehaviours.AgentState.Flee;

			}
			break;

		case boidState.Arrive:
			for (int i = 0; i < boids.Length; i++) {


				steeringScript = boids [i].GetComponent<SteeringBehaviours> ();
				steeringScript.aiState = SteeringBehaviours.AgentState.Arrive;

			}
			break;

		case boidState.Face:
			for (int i = 0; i < boids.Length; i++) {


				steeringScript = boids [i].GetComponent<SteeringBehaviours> ();
				steeringScript.aiState = SteeringBehaviours.AgentState.Face;

			}
			break;

		case boidState.Persue:

			for (int i = 0; i < boids.Length; i++) {


				steeringScript = boids [i].GetComponent<SteeringBehaviours> ();
				steeringScript.aiState = SteeringBehaviours.AgentState.Persue;

			}
			break;

		case boidState.Wander:
			for (int i = 0; i < boids.Length; i++) {


				steeringScript = boids [i].GetComponent<SteeringBehaviours> ();
				steeringScript.aiState = SteeringBehaviours.AgentState.Wander;

			}
			break;

		case boidState.Align:

			for (int i = 0; i < boids.Length; i++) {


				steeringScript = boids [i].GetComponent<SteeringBehaviours> ();
				steeringScript.aiState = SteeringBehaviours.AgentState.Align;

			}
			break;


		}
			

		}





}