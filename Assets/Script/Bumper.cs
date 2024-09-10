using UnityEngine;

public class Bumper : MonoBehaviour
{
	public float Bounce = 10f;

	readonly float y = 0.2f;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			collision.rigidbody.AddForce(0f, Bounce * y, Bounce, ForceMode.Impulse);
		}
	}
}

