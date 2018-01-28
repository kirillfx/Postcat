using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour {

	void OnDrawGizmos() {
		Gizmos.color = Color.gray;
		
		Rigidbody2D target = gameObject.GetComponent<HingeJoint2D>().connectedBody;
		
		if (target != null)
			Gizmos.DrawLine(transform.position, target.transform.position);
	}

}
