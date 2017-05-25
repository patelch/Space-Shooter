using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Rigidbody rbody;

	public float speed;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody> ();
		rbody.velocity = speed * transform.forward;
	}
}
