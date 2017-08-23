using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	private Renderer material;

	public float ScrollSpeed;

	// Use this for initialization
	void Start () {

		//StartPosition = gameObject.transform.position;
		material = gameObject.GetComponent <Renderer>();
		 
	}
	
	// Update is called once per frame
	void Update () {
		
		//float NewPos = Mathf.Repeat (Time.time * ScrollSpeed, TileSizeZ);
		//transform.position = StartPosition + Vector3.forward * NewPos;

		material.material.mainTextureOffset = new Vector2 (0, Time.time * ScrollSpeed );
		
	}
}
