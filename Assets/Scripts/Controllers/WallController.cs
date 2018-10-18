using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour 
{
	void OnTriggerEnter (Collider other) 
	{
		if(other.CompareTag("SnakeMain")) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
