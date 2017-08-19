using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandromRotator : MonoBehaviour {

	private Rigidbody body;
	private float tumble;

	// Use this for initialization
	void Start () {

		tumble = Random.Range (1f, 5f);
		body = gameObject.GetComponent<Rigidbody>();
		body.angularVelocity = Random.insideUnitSphere * tumble;
		body.velocity = new Vector3 (Random.Range (0.5f, 0.5f), 0.0f, Random.Range (-2f, -4f));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
