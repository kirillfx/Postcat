using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostcatController : MonoBehaviour {

	public float speed = 10.0f;
	public float gas = 100.0f;
	
	Rigidbody2D rb;


	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}


	void Start () {
		
	}
	

	void FixedUpdate () {

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		
		rb.MovePosition(rb.transform.position + 
			new Vector3(h, v, 0.0f) * speed * Time.fixedDeltaTime);
	}
}
