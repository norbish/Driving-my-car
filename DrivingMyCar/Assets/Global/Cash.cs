using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Cash : MonoBehaviour {

	public Text Cash_text;
	public static long total_cash = 0;
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Cash_text.text ="Cash: " +  total_cash + "$";
	}
}
