using System;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public static event Action OnFoodHasBeenEaten = delegate { };

	void OnTriggerEnter (Collider other)
	{
        OnFoodHasBeenEaten();
        Destroy(gameObject);
	}
}
