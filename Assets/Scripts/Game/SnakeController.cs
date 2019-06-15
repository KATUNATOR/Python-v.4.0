using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeController : MonoBehaviour
{
    public static event Action OnTailDetected = delegate { };

	public float MoveSpeed;
	public float RotateSpeed;

	public float z_offset = -0.5f;

	public GameObject TailPrefab;
	public Text TextScore;
	public Color[] rgb = new Color[5];
	public List<GameObject> tailObj = new List<GameObject>();

	private void Start ()
	{
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));

		tailObj.Add(gameObject);
	}

    private void OnEnable()
    {
        FoodController.OnFoodHasBeenEaten += HandlerOnFoodHasBeenEaten;
    }

    private void OnDisable()
    {
        FoodController.OnFoodHasBeenEaten -= HandlerOnFoodHasBeenEaten;
    }

    private void Update ()
	{
		transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.down * RotateSpeed * Time.deltaTime);
		}
	}

    private void HandlerOnFoodHasBeenEaten()
    {
        AddTail();
    }

    public void AddTail ()
	{
		Vector3 newPos = tailObj[tailObj.Count - 1].transform.position;
		newPos.z -= z_offset;

		tailObj.Add(GameObject.Instantiate(TailPrefab, newPos, Quaternion.identity) as GameObject);

		tailObj[tailObj.Count - 1].GetComponent<Renderer>().material.color = rgb[tailObj.Count % 5];
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeTail") && other.GetComponent<TailController>().ID > 2)
        {
            OnTailDetected();
        }
    }
}
