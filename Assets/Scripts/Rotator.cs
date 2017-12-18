using UnityEngine;
// How to make a COLOR SWITCH Replica in Unity (Livestream Tutorial)

public class Rotator : MonoBehaviour 
{
   // This script will rotate the transform component 
   // on the z axis

   	//adj in the inspector
	public float speed = 100f;// 100 deg every second
	
	// Update is called once per frame
	void Update () 
	{
		                 //x   y     z       
		transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}
}//endclass
