using UnityEngine;

public class Kill : MonoBehaviour
{
	[SerializeField] GameManager gameManager;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			Destroy(collision.gameObject);
			gameManager.OnKillBall();
		}
	}
}
