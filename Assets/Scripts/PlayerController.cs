using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // We should write this if we want our class variables to be visible in the editor
public class Boundary {

	public float maxX, minX, maxZ, minZ;

}

public class PlayerController : MonoBehaviour {

	private Rigidbody body;
	private float NextFire;
	private GameObject NewBolt;
	private AudioSource Audio;

	public float Speed;
	public float tilt;
	public float FireRate;
	public Boundary boundary;
	public Transform SpawnPoint;
	public GameObject Bolt;


	// Use this for initialization
	void Start () 
	{

		body = gameObject.GetComponent<Rigidbody>();
		Audio = gameObject.GetComponent<AudioSource> ();
		
	}

	void Update ()
	{

		FireBolt ();

	}
	
	void FixedUpdate () //If we have a physical object, we should put it's behaviour in FixedUpdate
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

		if (Input.GetMouseButton(0) && Time.time > NextFire) {

			Audio.Play ();

			NextFire = Time.time + FireRate;

			NewBolt = Instantiate (Bolt, SpawnPoint.position, SpawnPoint.rotation);

		}

	}

}
