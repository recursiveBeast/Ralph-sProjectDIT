using UnityEngine;
using System.Collections;

public class statePatternSim : MonoBehaviour {
	// this is the main file for the main FSM of the simulation




	public enum gameModes
	{
		Mode1,
		Mode2,
		Mode3
	};   // have this variable choose the game modes in inspector

	public gameModes gameMode;

	[HideInInspector] public ISimState currentState;

	[HideInInspector] public demoMode1 demoMode1;
	[HideInInspector] public demoMode2 demoMode2;
	[HideInInspector] public demoMode3 demoMode3;

	// why is this private?
	private void Awake(){
		demoMode1 = new demoMode1 (this); // what does "this" do? 
		demoMode2 = new demoMode2 (this);
		demoMode3 = new demoMode3 (this);
	
	}

	void Start() {



	}

	void Update(){
		checkStates ();
	}

	void checkStates(){
	
		switch (gameMode) {
		case gameModes.Mode1:
			currentState = demoMode1; //how does this work? 
			break;
		case gameModes.Mode2:
			currentState = demoMode2;
			break;
		case gameModes.Mode3:
			currentState = demoMode3;
			break;
	
		}

	}

}
