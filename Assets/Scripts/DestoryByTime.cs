﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByTime : MonoBehaviour {

	public float LifeTime;

	// Use this for initialization
	void Start () {

		Destroy (gameObject, LifeTime);
		
	}

}
