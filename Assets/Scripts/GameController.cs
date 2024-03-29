﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start() {
		score = 0;
		gameOver = false;
		restart = false;

		restartText.text = "";
		gameOverText.text = "";

		UpdateScore ();
		StartCoroutine(SpawnWaves ());
	}

	void Update() {
		if (restart && Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("Main");
		}
	}

	IEnumerator SpawnWaves() {
		
		while (!gameOver) {
			yield return new WaitForSeconds (startWait);

			for (int i = 0; i < hazardCount; i++) {

				Vector3 spawnPosition = new Vector3 (Random.Range (-1 * spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}	

			yield return new WaitForSeconds (waveWait);
		}

		if (gameOver) {
			restartText.text = "Press 'R' to restart";
			restart = true;
		}
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score.ToString ();
	}

	public void AddScore(int newScore) {
		score += newScore;
		UpdateScore ();
	}

	public void GameOver() {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
