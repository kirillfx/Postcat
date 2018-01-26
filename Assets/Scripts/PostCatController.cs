using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostCatController : MonoBehaviour {

	public float speed = 10.0f;
	Rigidbody2D rb;


	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		
		// rb.MovePosition(new Vector3(h,v, 0.0f) * speed);
		rb.MovePosition(rb.transform.position + 
			new Vector3(h, v, 0.0f) * speed * Time.fixedDeltaTime);
	}
}
