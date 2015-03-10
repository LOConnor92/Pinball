using UnityEngine;
using System.Collections;

public class FollowBall : MonoBehaviour
{
	public Transform ball;
	public float height;
	public float minPos;
	public float maxPos;

	Vector3 pos;

	void Start()
	{
		pos = transform.position;
	}

	void FixedUpdate()
	{
		if (pos.z != Mathf.Clamp (ball.position.z, minPos, maxPos))
			pos.z = Mathf.Clamp(ball.position.z, minPos, maxPos);
		if (transform.position != Vector3.Lerp (transform.position, pos, Time.deltaTime))
			transform.position = Vector3.Lerp (transform.position, pos, Time.deltaTime);
	}
}