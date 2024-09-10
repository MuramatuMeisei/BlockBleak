using UnityEngine;

public class Broken : MonoBehaviour
{
	[SerializeField] private GameManager gameManager;
	public int point = 100;
	private void Start()
	{
		if (gameManager == null)
		{
			gameManager = FindObjectOfType<GameManager>();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			Destroy(gameObject);
			gameManager.AddScore(point);
			gameManager.OnBroken();
		}
	}
}
