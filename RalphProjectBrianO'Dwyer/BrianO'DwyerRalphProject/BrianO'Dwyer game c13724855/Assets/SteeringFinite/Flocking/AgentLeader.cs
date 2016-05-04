using UnityEngine;
using System.Collections;

public class AgentLeader : MonoBehaviour {

	// Use this for initialization

	public float moveSpeed = 10f;
	public GameObject feeler;
	WanderBasic radiusScript;
	Vector3 p;

	void Start () {
		radiusScript = feeler.GetComponent<WanderBasic> ();
		p = radiusScript.point;
	}

	// Update is called once per frame
	void Update () {
		Vector3 moveDirection = (p- transform.position).normalized;
		transform.position += moveDirection * moveSpeed * Time.deltaTime;

	}
}
