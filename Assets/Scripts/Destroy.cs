using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public GameObject Explosion;
	public GameObject PlayerExplosion;
	public int Score;

	private GameController gamecontroller;
	private GameObject GameControllerObject;

	void Start ()
	{
		GameControllerObject = GameObject.FindWithTag ("GameController");

		if (GameControllerObject != null) {
		
			gamecontroller = GameControllerObject.GetComponent<GameController> ();
		
		}

		if (GameControllerObject == null) {
		
			Debug.Log ("Cannot Find the Game Controller");
		
		}

	}

	void OnTriggerEnter (Collider thing){
	
		if (thing.tag == "Shredder") {
		
			return;
		
		}

		Instantiate (Explosion, transform.position, transform.rotation);
		gamecontroller.AddScore (Score);

		if (thing.tag == "Player") {
		
			Instantiate (PlayerExplosion, thing.transform.position, thing.transform.rotation);
			gamecontroller.RestartLevel ();
		
		}

		Destroy (thing.gameObject);
		Destroy (gameObject);
	
	}

}
