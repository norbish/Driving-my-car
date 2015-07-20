using UnityEngine;
using System.Collections;

public class CarInitiate : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		CarController.Car_Ready_Third_Camera = true;
		CarController.Car_Ready_drive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
