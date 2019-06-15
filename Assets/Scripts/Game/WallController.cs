using System;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public static event Action OnSnakeDetected = delegate { };

    void OnTriggerEnter (Collider other)
	{
        OnSnakeDetected();
	}
}
