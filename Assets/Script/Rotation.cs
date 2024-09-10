using UnityEngine;

public class Rotation : MonoBehaviour
{
	public float rotAngle = 4f;
	private void FixedUpdate()
	{
		transform.Rotate(0f, rotAngle, 0f);
	}
}
