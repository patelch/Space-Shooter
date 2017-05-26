using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject astroidExplosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameObject gameControllerObject;
	private GameController gameController;

	void Start() {

		gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");

		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
	}

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag ("Boundary")) {
			return;
		}

		// astroid explosion
		Instantiate (astroidExplosion, transform.position, transform.rotation);

		if (other.CompareTag ("Player")) {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		Destroy (other.gameObject); // destroy laser
		Destroy (gameObject); // destroy astroid
		gameController.AddScore(scoreValue);
	}

}
