using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject[] Hazards;
	public Vector3 SpawnValue;
	public GUIText ScoreText;
	public GUIText RestartText;
	public GUIText GameOverText;
	public int WaveCount;
	public float StartWait;
	public float SpawnWait;
	public float WaveWait;


	private int Score;
	private bool Restart;
	private bool GameOver;


	void Start ()
	{

		StartCoroutine	(SpawnWaves ());
		UpdateScore ();
		Restart = false;
		GameOver = false;
		RestartText.text = "";
		GameOverText.text = "";
	
	}


	IEnumerator SpawnWaves ()
	{
		while (true) {
			yield return new WaitForSeconds (StartWait);
			for (int i = 0; i < WaveCount; i++) {

				GameObject Hazard = Hazards [(Random.Range (0, Hazards.Length))]; 
				Vector3 SpawnPosition = new Vector3 (Random.Range (-SpawnValue.x, SpawnValue.x), SpawnValue.y, SpawnValue.z);
				Quaternion SpawnRotation = Quaternion.identity;
				Instantiate (Hazard, SpawnPosition, SpawnRotation);
				SpawnWait = Random.Range (0f, 1f);
				yield return new WaitForSeconds (SpawnWait);
			
			}

			yield return new WaitForSeconds (WaveWait);

			if (GameOver) {

				RestartLevel ();
				break;

			}
				
		}
	
	}

	void Update ()
	{

		if (Restart == true && Input.GetKeyDown (KeyCode.R)) {
		
			EditorSceneManager.LoadScene ("Main");
		
		}

	}

	public void AddScore (int ScoreValue)
	{
	
		Score += ScoreValue;
		UpdateScore ();
	
	}

	void UpdateScore ()
	{
	
		ScoreText.text = "Score: " + Score;
	
	}

	public void RestartLevel ()
	{
		GameOverText.text = "GAME OVER";
		RestartText.text = "Press R to Restart!";
		Restart = true;
		GameOver = true;

	}

}



