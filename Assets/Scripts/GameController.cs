﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject Hazard;
	public Vector3 SpawnValue;
	public int WaveCount;
	public float StartWait;
	public float SpawnWait;
	public float WaveWait;

	void Start (){
	
		StartCoroutine	(SpawnWaves ());
	
	}


	IEnumerator SpawnWaves ()
	{
		while (true) {
			yield return new WaitForSeconds (StartWait);
			for (int i = 0; i < WaveCount; i++) {
				
				Vector3 SpawnPosition = new Vector3 (Random.Range (-SpawnValue.x, SpawnValue.x), SpawnValue.y, SpawnValue.z);
				Quaternion SpawnRotation = Quaternion.identity;
				Instantiate (Hazard, SpawnPosition, SpawnRotation);
				yield return new WaitForSeconds (SpawnWait);
			
			}

			yield return new WaitForSeconds (WaveWait);
		}
	
	}

}


