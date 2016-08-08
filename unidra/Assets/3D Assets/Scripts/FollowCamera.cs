using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float rotAngle = 180.0f;
	public float horizontalAngle = 0.0f;
	public float verticalAngle = 0.0f;

	public Transform lookTarget;
	public Vector3 offset = Vector3.zero;

	public float distance = 5.0f;

	InputManager inputManager;
	void Start () {
		inputManager = FindObjectOfType<InputManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate () {
		// 드래그 입력으로 카메라 회전각을 갱신한다.
		if (inputManager.Moved ()) {
			float anglePerPixel = rotAngle / (float)Screen.width;
			Vector2 delta = inputManager.GetDeltaPosition ();
			horizontalAngle += delta.x * anglePerPixel;
			horizontalAngle = Mathf.Repeat (horizontalAngle, 360.0f);
			verticalAngle -= delta.y * anglePerPixel;
			verticalAngle = Mathf.Clamp (verticalAngle, -60.0f, 60.0f);
		}
			
		// renew camera position and rotation angle
		if (lookTarget != null) {
			Vector3 lookPosition = lookTarget.position + offset;
			Vector3 relativePos = Quaternion.Euler (verticalAngle, horizontalAngle, 0) *
			                      new Vector3 (0f, 0f, -distance);

			transform.position = lookPosition + relativePos;
			transform.LookAt (lookPosition);

			RaycastHit hitInfo;
			if (Physics.Linecast (lookPosition, transform.position, out hitInfo,
				    1 << LayerMask.NameToLayer ("Ground"))) {
				transform.position = hitInfo.point;
			}
		}
	}
}
