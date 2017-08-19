using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMovement : MonoBehaviour {

	public float Speed;
	private Rigidbody body;

	// Use this for initialization
	void Start () {

		body = gameObject.GetComponent<Rigidbody>();
		body.velocity = transform.forward * Speed;
		
	}

}
