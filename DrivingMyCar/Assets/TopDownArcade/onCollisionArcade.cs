﻿using UnityEngine;
using System.Collections;

public class onCollisionArcade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision objects)
	{
		if(objects.gameObject.tag == "ArcadeCar")
		objects.gameObject.SetActive (false);
	}
}
