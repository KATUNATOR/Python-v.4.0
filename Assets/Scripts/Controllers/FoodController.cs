using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour 
{
	void OnTriggerEnter (Collider other) 
	{
		if(other.CompareTag("SnakeMain")) 
		{
			other.GetComponent<SnakeController>().AddTail();
		}
		Destroy(gameObject);
	}
}
