using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public GameObject Explosion;
	public GameObject PlayerExplosion;

	void OnTriggerEnter (Collider thing){
	
		if (thing.tag == "Shredder") {
		
			return;
		
		}

		Instantiate (Explosion, transform.position, transform.rotation);

		if (thing.tag == "Player") {
		
			Instantiate (PlayerExplosion, thing.transform.position, thing.transform.rotation);
		
		}

		Destroy (thing.gameObject);
		Destroy (gameObject);
	
	}

}
