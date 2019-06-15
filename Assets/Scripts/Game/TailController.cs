using UnityEngine;

public class TailController : MonoBehaviour
{
	public float MoveSpeed;
	public Vector3 tailTarget;
	public GameObject tailTargetObject;
	public SnakeController SnakeMain;
	public int ID;

	void Start ()
	{
		SnakeMain = GameObject.FindGameObjectWithTag("SnakeMain").GetComponent<SnakeController>();
		MoveSpeed = SnakeMain.MoveSpeed + 0.5f;
		tailTargetObject = SnakeMain.tailObj[SnakeMain.tailObj.Count - 2];
		ID = SnakeMain.tailObj.IndexOf(gameObject);
	}

	void Update ()
	{
		tailTarget = tailTargetObject.transform.position;
		tailTarget.z -= SnakeMain.z_offset;
		transform.LookAt(tailTarget);
		transform.position = Vector3.Lerp(transform.position, tailTarget, MoveSpeed * Time.deltaTime);
	}
}
