using UnityEngine;
using System.Collections;

public class stateTemplate :ISimState {


	private readonly statePatternSim simControl;

	public stateTemplate (statePatternSim statePatternSim){
		simControl = statePatternSim;
	}



	public void UpdateState(){

	}


	// first state make class called PatrolState
	public void ToDemoState1(){


	}

	public void ToDemoState2(){

	}

	public void ToDemoState3(){


	}
}
