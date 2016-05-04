using UnityEngine;
using System.Collections;

public interface ISimState
{
	//List of functions that each class that implements this interface is required to have 
	void UpdateState();



	// first state make class called PatrolState
	void ToDemoState1();

	void ToDemoState2();

	void ToDemoState3();
}