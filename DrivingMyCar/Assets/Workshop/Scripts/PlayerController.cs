using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public Rigidbody player;
	public GameObject Camera;
	public Vector3 Position_Player_Camera;

	public float speed;
	public float RotateSpeed;
	public static bool button_forward = false;
	public static bool button_back = false;
	public static bool button_left = false;
	public static bool button_right = false;

	public static bool inCar = false;
	public GameObject car;
	void Start () 
	{
		//MovePlayer ();
	}
	//void update()
	//{

	//}
	
	// Update is called once per frame
	void Update () 
	{
		float Movement = Input.GetAxis ("Vertical");
		float rotate = Input.GetAxis ("Horizontal");

		//Camera.transform.position = Vector3.Lerp (
			//transform.position + Position_Player_Camera/*pluss minus ekstra for å få plass*/, player.position , Time.deltaTime * 1/*smoothness*/);
		//Camera.transform.rotation = transform.rotation;

		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		//player.velocity = movement * speed;
		if (Movement > 0 && inCar == false) //arrow controlled
			transform.Translate(Vector3.forward * Time.deltaTime * speed * Movement);
		if (button_forward == true)//button controlled
			transform.Translate (Vector3.forward * Time.deltaTime * speed);


		if (Movement < 0 && inCar == false) 
			transform.Translate(Vector3.back * Time.deltaTime * speed * -Movement);
		if(button_back == true)
			transform.Translate(Vector3.back * Time.deltaTime * speed);


		if(rotate < 0 && inCar == false)
			transform.Rotate (Vector3.down * Time.deltaTime * RotateSpeed * -rotate);
		if(rotate > 0 && inCar == false)
			transform.Rotate (Vector3.up * Time.deltaTime * RotateSpeed * rotate);

		/*if (inCar)
		{
			transform.parent = car.transform;
		}*/
		//player.rotation = Quaternion.Euler (0.0f, rotate, 0.0f);
	}


}
