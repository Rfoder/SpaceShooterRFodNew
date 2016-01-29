﻿using UnityEngine;
using System.Collections;

public class DestroyByContaxt : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		        {
			Debug.Log ("Cannot Find 'GameController' Script");
				}
	}

	void OnTriggerEnter(Collider other){
				if (other.tag == "Boundary") {
						return;
				}
				//	Debug.Log (other.name);
				Instantiate(explosion, transform.position, transform.rotation);
		gameController.GameOver ();
		if (other.tag == "Player") {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
		gameController.AddScore (scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
		}
}
