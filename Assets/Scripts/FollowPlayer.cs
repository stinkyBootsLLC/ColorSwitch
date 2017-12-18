using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// How to make a COLOR SWITCH Replica in Unity (Livestream Tutorial)

public class FollowPlayer : MonoBehaviour 
{
	// this script will make the camera follow the player object 
	// only in the UP direction 
	// when player falls down then GAME OVER

	public Transform player;


	void Update () 
	{
		if (player.position.y > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
		}
		
	}
}//endclass
