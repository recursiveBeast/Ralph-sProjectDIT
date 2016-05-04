using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {


	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) {
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
		}
	}
}
