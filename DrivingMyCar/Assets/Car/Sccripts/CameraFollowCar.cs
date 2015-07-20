using UnityEngine;
using System.Collections;

public class CameraFollowCar : MonoBehaviour {
	public Transform car;
	public float smoothness = 5.0f;
	private Vector3 campos;
	// Use this for initialization
	void Start () {
		campos = new Vector3 (0, 48, -50);
		//cam.transform.rotation = Quaternion.Euler(Vector3.zero);

		//cam = GameObject.Find("MainCamera");
		//cam.transform.position = newBall.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (
			transform.position, car.position + campos,
			Time.deltaTime * smoothness);
	}
}
