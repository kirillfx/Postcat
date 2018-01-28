using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rope : MonoBehaviour {

	public Transform segment;
	public Transform end;
	public int totalSegments;
	public float boxRadius = 0.1f;

	private Rigidbody2D rb;
	private CircleCollider2D col;


	public void InitializeRope() {
		if (end != null) {

			float dist = Vector3.Distance(transform.position, end.position) - col.radius - boxRadius;

			float segmentLength = dist / (float) totalSegments;

			Transform previousSegment = this.transform;
			Vector3 targetDir = (end.position - transform.position).normalized;

			foreach(int i in Enumerable.Range(0, totalSegments)) {

				Vector3 segemntPos = previousSegment.position + targetDir * segmentLength;

				GameObject currentSegment = Instantiate(segment, segemntPos, segment.rotation).gameObject;
				currentSegment.transform.right = previousSegment.position - currentSegment.transform.position;
				
				CapsuleCollider2D col = currentSegment.GetComponent<CapsuleCollider2D>();
				col.size = new Vector2(segmentLength, 0.2f);
				col.offset = new Vector2(segmentLength / 2.0f, 0.0f);

				HingeJoint2D hj = currentSegment.GetComponent<HingeJoint2D>();
				hj.connectedBody = previousSegment.GetComponent<Rigidbody2D>();
				hj.anchor = new Vector2(segmentLength, 0.0f);
				
				previousSegment = currentSegment.transform;
			}

			end.GetComponent<HingeJoint2D>().connectedBody = previousSegment.GetComponent<Rigidbody2D>();
		}
	}


	void Awake() {

		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<CircleCollider2D>();

		InitializeRope();

	}

}
