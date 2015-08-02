using UnityEngine;
using System.Collections;

public class CarControllerV7 : MonoBehaviour {

	public GameObject Object_Car;
	public Rigidbody  Rigidbody_Car;
	public Vector3 Center_of_mass = new Vector3 (0, 0, 0);
	public static bool Car_Ready_drive = true;
	public static bool Car_Ready_Third_Camera =  false;
	public Vector3 Position_Player_Camera;
	public static bool Car_Ready_Second_Camera = false;
	public GameObject secondary_Camera;
	public GameObject third_Camera;

	public GameObject FR_wheel_object;
	public GameObject FL_wheel_object;
	public GameObject RR_wheel_object;
	public GameObject RL_wheel_object;


	public int forward_Speed;
	public int backward_Speed;
	public Vector3 steer_Rotation_Angle;
	void Start () {
		Rigidbody_Car.centerOfMass = Center_of_mass;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxis ("Vertical") > 0 && Car_Ready_drive == true) 
			drive_Forward ();
		else if (Input.GetAxis ("Vertical") < 0 && Car_Ready_drive == true)
			drive_Backward();

		if (Input.GetAxis ("Horizontal") < 0)
			turn_Left ();
		else if (Input.GetAxis ("Horizontal") > 0)
			turn_Right ();

		third_Camera.transform.position = Vector3.Lerp (transform.position + Position_Player_Camera/*pluss minus ekstra for å få plass*/, Rigidbody_Car.position , Time.deltaTime * 1/*smoothness*/);
		//third_Camera.transform.rotation = transform.rotation;
	}


	public void drive_Forward()
	{
		//Rigidbody_Car.AddRelativeForce (new Vector3(0, 0, 7000));
		Rigidbody_Car.MovePosition (transform.position + transform.forward * Time.deltaTime  * Input.GetAxis ("Vertical") * forward_Speed);
	}
	public void drive_Backward()
	{
		Rigidbody_Car.MovePosition (transform.position + transform.forward * Time.deltaTime  * -backward_Speed);
	}
	public void turn_Left()
	{
		Quaternion car_Steer_Left = Quaternion.Euler (-steer_Rotation_Angle * Time.deltaTime);
		Rigidbody_Car.MoveRotation (Rigidbody_Car.rotation * car_Steer_Left);
		//Rigidbody_Car.MoveRotation( -steer_Angle);
	}
	public void turn_Right()
	{
		Quaternion car_Steer_Right = Quaternion.Euler (steer_Rotation_Angle * Time.deltaTime);
		Rigidbody_Car.MoveRotation (Rigidbody_Car.rotation * car_Steer_Right);
	}
}
