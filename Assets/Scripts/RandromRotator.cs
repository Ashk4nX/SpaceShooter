using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandromRotator : MonoBehaviour {

	private Rigidbody body;
	public float tumble;

	// Use this for initialization
	void Start () {

		body = gameObject.GetComponent<Rigidbody>();
		body.angularVelocity = Random.insideUnitSphere * tumble;
		body.velocity = new Vector3 (Random.Range (0.5f, 0.5f), 0.0f, Random.Range (-2f, -6f));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
