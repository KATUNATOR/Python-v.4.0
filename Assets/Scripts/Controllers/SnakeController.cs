using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeController : MonoBehaviour 
{

	public float MoveSpeed;
	public float RotateSpeed;
	public float z_offset = -0.5f;
	public GameObject TailPrefab;
	public Text TextScore;
	public Color[] rgb = new Color[5];
	public List<GameObject> tailObj = new List<GameObject>();

	void Start () 
	{
		tailObj.Add(gameObject);
	}
	
	void Update () 
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

	public void AddTail () 
	{		
		Vector3 newPos = tailObj[tailObj.Count - 1].transform.position;
		newPos.z -= z_offset;

		TextScore.text = System.Convert.ToString(tailObj.Count - 1);
		
		tailObj.Add(GameObject.Instantiate(TailPrefab, newPos, Quaternion.identity) as GameObject);

		tailObj[tailObj.Count - 1].GetComponent<Renderer>().material.color = rgb[tailObj.Count % 5];
	}
}
