﻿using UnityEngine;
using System.Collections;

public class RotateTrackArcade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,Time.deltaTime*15,0);
	
	}
}
