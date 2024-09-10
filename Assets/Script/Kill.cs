using System;
using UnityEngine;

public class Kill : MonoBehaviour
{
	public static event Action OnObjectKill;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ball")
		{
			Destroy(collision.gameObject);
			OnObjectKill.Invoke();
		}
	}
}
