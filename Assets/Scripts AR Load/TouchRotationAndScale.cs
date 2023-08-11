using UnityEngine;

public class TouchRotationAndScale : MonoBehaviour
{
	private Vector2 touchStartPos;
	private float rotationSpeed = 1f;
	private float scaleSpeed = 0.01f;

	private void Update()
	{
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				touchStartPos = touch.position;
			}
			else if (touch.phase == TouchPhase.Moved)
			{
				// Rotate the object based on touch delta position
				float rotationX = (touch.position.y - touchStartPos.y) * rotationSpeed;
				float rotationY = -(touch.position.x - touchStartPos.x) * rotationSpeed;
				transform.Rotate(rotationX, rotationY, 0, Space.World);

				// Update the touch start position
				touchStartPos = touch.position;
			}
		}
		else if (Input.touchCount == 2)
		{
			Touch touch1 = Input.GetTouch(0);
			Touch touch2 = Input.GetTouch(1);

			if (touch2.phase == TouchPhase.Moved)
			{
				// Calculate the distance between the two touches
				Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
				Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;
				float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
				float touchDeltaMag = (touch1.position - touch2.position).magnitude;
				float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

				// Scale the object based on touch delta magnitude difference
				float scaleAmount = deltaMagnitudeDiff * scaleSpeed;
				Vector3 newScale = transform.localScale + new Vector3(scaleAmount, scaleAmount, scaleAmount);
				transform.localScale = newScale;
			}
		}
	}
}