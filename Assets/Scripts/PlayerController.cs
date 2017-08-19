using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {

	public float maxX, minX, maxZ, minZ;

}

public class PlayerController : MonoBehaviour {

	private Rigidbody body;
	private GameObject NewBolt;

	public float Speed;
	public float tilt;
	public Boundary boundary;
	public GameObject SpawnPoint;
	public GameObject Bolt;


	// Use this for initialization
	void Start () 
	{

		body = gameObject.GetComponent<Rigidbody>();
		
	}

	void Update ()
	{

		FireBolt ();

	}
	
	void FixedUpdate () 
	{

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 Movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		body.velocity = Movement * Speed;
		body.position = new Vector3 
		(
			Mathf.Clamp(body.position.x, boundary.minX, boundary.maxX),
			0.0f, 
			Mathf.Clamp(body.position.z, boundary.minZ, boundary.maxZ) 
		);

		body.rotation = Quaternion.Euler (0.0f, 0.0f, body.velocity.x * -tilt);

	}

	void FireBolt ()
	{

		if (Input.GetMouseButtonDown(0)) {

			NewBolt = Instantiate (Bolt, SpawnPoint.transform.position, SpawnPoint.transform.rotation) as GameObject;	

		}

	}

}
