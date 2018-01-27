using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRootController : MonoBehaviour {

	public float speed = 5.0f;
	public GameObject cargo;
	public int totalSegments = 2;
	public Transform segment;

	Rigidbody2D rb;


	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		// float dist = Vector3.Distance(transform.position, cargo.transform.position);
		// float segmentSize =  dist / totalSegments;
		
		// GameObject previousSegment = this.gameObject;
		// for(int i = 0; i < totalSegments; i++) {
		// 	GameObject currentSegment = 
		// 		Instantiate(segment, previousSegment.transform.position - 
		// 			Vector3.up * segmentSize, segment.rotation).gameObject;
			
		// 	Transform body = currentSegment.transform.GetChild(0).transform;
			
		// 	body.localScale = new Vector3(1.0f, segmentSize, 1.0f);
		// 	body.position = new Vector3(1.0f, segmentSize / 2, 1.0f);

		// 	var hj = currentSegment.GetComponent<HingeJoint2D>();
		// 	hj.connectedBody = previousSegment.GetComponent<Rigidbody2D>();
		// 	previousSegment = currentSegment;
		// }
		
		// var cargoHJ = cargo.GetComponent<HingeJoint2D>();
		// cargoHJ.connectedBody = previousSegment.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(h, v, 0.0f);
		rb.AddForce(movement * speed);
		// rb.MovePosition(transform.position 
		// 	+ movement * speed * Time.fixedDeltaTime);
		rb.AddForce(movement * speed);
	}
}
