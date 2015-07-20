using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Fame : MonoBehaviour {

	public Text Fame_text;
	public static long total_Fame = 0;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Fame_text.text ="Fame: " + total_Fame + "/100";
	}
}
