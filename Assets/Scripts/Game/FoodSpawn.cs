using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour 
{
	public float x = 8.8f;
	public float z = 8.8f;
	public GameObject FoodPrefab;
	public GameObject curFood;
	
	Vector3 NewPos ()
	{
		return new Vector3(Random.Range(-x, x), 0.5f, Random.Range(-z, z));
	}

	void Update () 
	{
		if(!curFood) 
		{
			curFood = GameObject.Instantiate(FoodPrefab, NewPos(), Quaternion.identity) as GameObject;
		}
	}
}
