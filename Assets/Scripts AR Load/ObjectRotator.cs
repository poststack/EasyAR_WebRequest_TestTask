using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour
{
	public float rotationSpeed = 50f;

	private bool rotateClockwise = true;

	void Start()
	{
		StartCoroutine(ChangeRotationDirection());
	}

	void Update()
	{
		RotateObject();
	}

	void RotateObject()
	{
		float rotationDirection = rotateClockwise ? 1f : -1f;
		transform.Rotate(Vector3.up, rotationDirection * rotationSpeed * Time.deltaTime);
	}

	IEnumerator ChangeRotationDirection()
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);
			rotateClockwise = !rotateClockwise;
		}
	}
}