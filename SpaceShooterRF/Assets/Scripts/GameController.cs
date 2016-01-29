using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject Hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText ScoreText;
	private int score;

	void Start ()
	{
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	
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
}
