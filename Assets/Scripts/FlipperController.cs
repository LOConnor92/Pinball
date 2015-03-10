using UnityEngine;
using System.Collections;

public class FlipperController : MonoBehaviour 
{
	public KeyCode press;
	public enum Angle{x, y, z};
	public Angle angle = Angle.x;
	public bool antiClockwise = false;
	public float maxRot;
	public float speed;

	Quaternion flipRot;
	Quaternion startRot;

	void Start()
	{
		startRot = transform.rotation;
		flipRot = Quaternion.Euler(transform.rotation.eulerAngles + WorkOutFlipRot());
	}

	Vector3 WorkOutFlipRot()
	{
		Vector3 ret = Vector3.zero;
		switch (angle) 
		{
		case Angle.x:
			ret = Vector3.right * maxRot;
			break;
		case Angle.y:
			ret = Vector3.up * maxRot;
			break;
		case Angle.z:
			ret = Vector3.forward * maxRot;
			break;
		}

		if (antiClockwise)
			ret = -ret;

		return ret;
	}

	void Update()
	{
		CanMove (Input.GetKey (press));
	}

	void CanMove(bool check)
	{
		if (check) {
			if (Mathf.Abs (Vector3.Distance (transform.rotation.eulerAngles, flipRot.eulerAngles)) > 0.01f)
				transform.rotation = Quaternion.Slerp (transform.rotation, flipRot, Time.deltaTime * speed);
			else
				transform.rotation = flipRot;
		}
		else 
		{
			if (Mathf.Abs (Vector3.Distance (transform.rotation.eulerAngles, startRot.eulerAngles)) > 0.01f)
				transform.rotation = Quaternion.Slerp (transform.rotation, startRot, Time.deltaTime * speed);
			else
				transform.rotation = startRot;
		}
	}
}