﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject Hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText ScoreText;
	public GUIText restartText;
	public GUIText gameOverText;


	private bool gameOver;
	private bool restart;
	private int score;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	
 	}
	void Update ()
	{
		if (restart) 
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
		}

	IEnumerator SpawnWaves ()
	{
		while (true)
		{

		yield return new WaitForSeconds (startWait);		
		for (int i = 0; i < hazardCount; i++) {

						Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
						Quaternion spawnRotation = Quaternion.identity;
						Instantiate (Hazard, spawnPosition, spawnRotation);
			            yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver)
			{
				restartText.text = "Press 'A' for Restart";
				restart = true;
				break;
			}
		}

	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
		}
	void UpdateScore ()
	{
		ScoreText.text = "Score: " + score;
	}
	public void GameOver ()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}
}
