using UnityEngine;
using System.Collections;

public class ArcadeCarController : MonoBehaviour {
	
	public GameObject Object_Car;
	public Rigidbody  Rigidbody_Car;
	private Transform thisTransform;
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
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{

			drive_Forward ();
		if (Input.GetAxis ("Vertical") < 0 && Car_Ready_drive == true)
			drive_Backward();
		
		if (Input.GetAxis ("Horizontal") < 0 && transform.position.x >= -23)//if posx >= -30 
			turn_Left ();
		else if (Input.GetAxis ("Horizontal") > 0 && transform.position.x <= 23)//if posx <= 30
			turn_Right ();
		else
			middle_Pos();
		
		third_Camera.transform.position = Vector3.Lerp (transform.position + Position_Player_Camera/*pluss minus ekstra for å få plass*/, Rigidbody_Car.position , Time.deltaTime * 1/*smoothness*/);
		//third_Camera.transform.rotation = transform.rotation;
	}
	
	
	public void drive_Forward()
	{

		//Rigidbody_Car.MovePosition (thisTransform.position + thisTransform.forward * Time.deltaTime  * forward_Speed);
	}
	public void drive_Backward()
	{
		//Rigidbody_Car.MovePosition (transform.position + transform.forward * Time.deltaTime  * -backward_Speed);
	}
	public void turn_Left()//må endres til å endre pos, ikke move pos.
	{

		thisTransform.localEulerAngles = new Vector3 (0, -10, 0);//endre til global steering variabel
		//Rigidbody_Car.MovePosition (transform.position + new Vector3(1,0,0)* -1  * Time.deltaTime * 45);
		Rigidbody_Car.position = thisTransform.position + new Vector3 (1, 0, 0) * -1 * Time.deltaTime * 45;
		//Rigidbody_Car.MoveRotation( -steer_Angle);
	}
	public void turn_Right()
	{
		thisTransform.localEulerAngles = new Vector3 (0, 10, 0);//endre til global steering variabel
		Rigidbody_Car.position = thisTransform.position + new Vector3 (1, 0, 0) * Time.deltaTime * 45;
	}
	public void middle_Pos()
	{
		thisTransform.eulerAngles = new Vector3 (0, 0, 0); 
	}
}
