using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public WheelCollider FR_wheel_collider;
	public WheelCollider FL_wheel_collider;
	public WheelCollider RR_wheel_collider;
	public WheelCollider RL_wheel_collider;
	public GameObject FR_wheel_object;
	public GameObject FL_wheel_object;
	public GameObject RR_wheel_object;
	public GameObject RL_wheel_object;

	public Rigidbody car;
	public Vector3 Center_of_mass = new Vector3 (0, 0, 0);
	public float max_speed_forward = 1500;
	public float max_Steer = 30;
	public float Force_brake = 1000;
	public float speed_reverse = 1000;

	private float steer = 0;

	public static bool Car_Ready_drive = false;
	public static bool Car_Ready_Third_Camera =  false;
	public static bool Car_Ready_Second_Camera = false;
	public GameObject secondary_Camera;
	public GameObject third_Camera;
	//private float brake = 0;

	void Start () {
		car.centerOfMass = Center_of_mass;
	}
	
	// Update is called once per frame
	void Update () 
	{


		float speed = RL_wheel_collider.rpm; //get speed
		if(Car_Ready_drive)
		steer = Input.GetAxis("Horizontal");



		if (Input.GetAxis ("Vertical") > 0 && Car_Ready_drive == true) {
			FR_wheel_collider.motorTorque = max_speed_forward;
			FL_wheel_collider.motorTorque = max_speed_forward;
			RR_wheel_collider.motorTorque = max_speed_forward;
			RL_wheel_collider.motorTorque = max_speed_forward;
		} else if (Input.GetAxis ("Vertical") < 0 && speed > 9 && Car_Ready_drive == true) {
			FR_wheel_collider.brakeTorque = Force_brake;
			FL_wheel_collider.brakeTorque = Force_brake;
			RR_wheel_collider.brakeTorque = Force_brake;
			RL_wheel_collider.brakeTorque = Force_brake;

		} else if (Input.GetAxis ("Vertical") < 0 && speed <= 9 && Car_Ready_drive == true) 
		{
			FR_wheel_collider.motorTorque = -speed_reverse;
			FL_wheel_collider.motorTorque = -speed_reverse;
			RR_wheel_collider.motorTorque = -speed_reverse;
			RL_wheel_collider.motorTorque = -speed_reverse;
			FR_wheel_collider.brakeTorque = 0;
			FL_wheel_collider.brakeTorque = 0;
			RR_wheel_collider.brakeTorque = 0;
			RL_wheel_collider.brakeTorque = 0;

		}
		else //zero_torque
		{
			FR_wheel_collider.motorTorque = 0;
			FL_wheel_collider.motorTorque = 0;
			RR_wheel_collider.motorTorque = 0;
			RL_wheel_collider.motorTorque = 0;
			FR_wheel_collider.brakeTorque = 0;
			FL_wheel_collider.brakeTorque = 0;
			RR_wheel_collider.brakeTorque = 0;
			RL_wheel_collider.brakeTorque = 0;

		}
		//set wheel collider steering angle(front wheels only)
		FR_wheel_collider.steerAngle = max_Steer * steer;
		FL_wheel_collider.steerAngle = max_Steer * steer;
		//match the wheel turning angle with collider angle:

		

		//Match the rotation of the wheel-mesh according to the rpm of the colliders
		FR_wheel_object.transform.Rotate ( FR_wheel_collider.rpm * 6 * Time.deltaTime,0,0);//eventuelt lage nytt gameobject for disse så de kan snurre og
		FL_wheel_object.transform.Rotate ( FL_wheel_collider.rpm * 6 * Time.deltaTime,0,0);
		RR_wheel_object.transform.Rotate ( RR_wheel_collider.rpm * 6 * Time.deltaTime,0,0);
		RL_wheel_object.transform.Rotate ( RL_wheel_collider.rpm * 6 * Time.deltaTime,0,0);
		//Debug.Log (speed);

		if(Input.GetAxis ("Horizontal")!=0){//trenger den for at hjula skal rotere ellers
		FR_wheel_object.transform.localEulerAngles = new Vector3 (transform.rotation.x ,max_Steer * steer,transform.rotation.z);
		FL_wheel_object.transform.localEulerAngles = new Vector3 (0,max_Steer * steer,0);
		}

		if (Car_Ready_Second_Camera == true)
			secondary_Camera.SetActive (true);
		if (Car_Ready_Third_Camera == true)
			third_Camera.SetActive (true);

	}
	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.gameObject.name == "Player") 
		{
			Car_Ready_drive = true;
			collision.transform.gameObject.SetActive (false);
			Car_Ready_Second_Camera = true;
		}
	}
}
