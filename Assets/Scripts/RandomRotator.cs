using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	private Rigidbody rbody;

	// Use this for initialization
	void Start () {

		rbody = GetComponent<Rigidbody> ();
		rbody.angularVelocity = tumble * Random.insideUnitSphere;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
