using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax;
	public float zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	private Rigidbody rbody;

	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;

	void Start() {
		rbody = GetComponent<Rigidbody> ();

		nextFire = 0.0f;
	}

	void Update() {

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

			nextFire = Time.time + fireRate;
		}
	
	}
		
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rbody.velocity = speed * movement;

		rbody.position = new Vector3 (
			Mathf.Clamp(rbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rbody.position.z, boundary.zMin, boundary.zMax) 
		);

		rbody.rotation = Quaternion.Euler (0.0f, 0.0f, rbody.velocity.x * -1 * tilt);
	}

}
