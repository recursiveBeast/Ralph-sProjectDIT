using UnityEngine;
using System.Collections;

public class simController : MonoBehaviour {

	public GameObject wall;
	public GameObject target;
	public bool showWall;
	public bool showTarget;
	public bool showGroup;

	// Use this for initialization
	     Mode1 mode1;
	    Mode2 mode2;
	    Mode3 mode3;



	public enum gameModes
	{
		Mode1,
		Mode2,
		Mode3
	}   // have this variable choose the game modes in inspector

	public gameModes gameMode;

	void Start () {
		mode1 =  GetComponent<Mode1> ();
		mode2 = GetComponent<Mode2> ();
		mode3 = GetComponent<Mode3> ();

	//	wall.SetActive (false);
		//target.SetActive (false);
	}
	

	void Update(){
		checkStates ();
	}

	void checkStates(){

		switch (gameMode) {
		case gameModes.Mode1:
			mode1.enabled = true;
			mode2.enabled = false;
			mode3.enabled = false;
			break;

		case gameModes.Mode2:
			mode1.enabled = false;
			mode2.enabled = true;
			mode3.enabled = false;
			break;

		case gameModes.Mode3:
			mode1.enabled = false;
			mode2.enabled = false;
			mode3.enabled = true;
			break;

		}
}

}