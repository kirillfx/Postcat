using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3F;
	public float maxCameraOffset = 5.0f;
    
    private Vector3 velocity = Vector3.zero;
	private Vector3 initialPos;


	void Awake() {

		initialPos = transform.position;

	}


	void FixedUpdate() {

		if (target != null) {
			Vector3 targetPosition = target.position;
			targetPosition.z = initialPos.z;
			targetPosition.y = Mathf.Clamp(targetPosition.y, -3.0f, 3.0f);
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		}

    }


}
