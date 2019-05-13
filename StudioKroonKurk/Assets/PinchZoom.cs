using UnityEngine;
using System.Collections;

// Hard copy from unity forum
public class PinchZoom : MonoBehaviour
{
	public float perspectiveZoomSpeed = 0.1f;        // The rate of change of the field of view in perspective mode.
	public float startingFoV, maxZoomedFoV;
	public Camera cam;

	private void Update()
	{
		// If there are two touches on the device...
		if(Input.touchCount == 2)
		{
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			// Otherwise change the field of view based on the change in distance between the touches.
			cam.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

			// Clamp the field of view to make sure it's between 0 and 180.
			cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, maxZoomedFoV, startingFoV);
		}
		else
		{
			// Otherwise change the field of view based on the change in distance between the touches.
			cam.fieldOfView += -Input.GetAxisRaw("Mouse ScrollWheel") * 5;

			// Clamp the field of view to make sure it's between 0 and 180.
			cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, maxZoomedFoV, startingFoV);
		}
	}

	public void ZoomOut()
	{
		StartCoroutine(ResetZoom());
	}

	private IEnumerator ResetZoom()
	{
		float curTime = 0f;
		float totalTime = 0.6f;

		float startVal = cam.fieldOfView;

		while(true)
		{
			yield return null;

			cam.fieldOfView = Mathf.Lerp(startVal, startingFoV, curTime / totalTime);

			curTime += Time.deltaTime;
			if(curTime > totalTime)
				break;
		}
	}
}
