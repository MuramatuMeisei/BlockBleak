using System;
using UnityEngine;

public class Broken : MonoBehaviour
{
	public static event Action<int> OnScoreAdded;
	public static event Action OnObjectBroken;
	
	public int point = 100;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			Destroy(gameObject);
			OnScoreAdded.Invoke(point);
			OnObjectBroken.Invoke();
		}
	}
}
