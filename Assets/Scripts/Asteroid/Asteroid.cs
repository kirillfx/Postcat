using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour {

	public float collisionDamageScale = 1.0f;
	public float rotSpeedScale = 10.0f;
	
	private float rotSpeed;
	private Rigidbody2D rb;


	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}


	void Start() {
		rotSpeed = Random.Range(-1.0f, 1.0f);
	}


	void OnCollisionEnter2D(Collision2D col) {

		GameObject obj = col.gameObject;
		
		if (obj.CompareTag("Player")) {
			float damage = col.relativeVelocity.magnitude * collisionDamageScale;
			Postcat postcat = obj.GetComponent<Postcat>();
			FindObjectOfType<AudioManager>().Play("hitAsteroid");
			postcat.ApplyDamage(damage);
			postcat.Crash();

			// Vector3 playerDir = 
			// 	(obj.transform.position - transform.position).normalized;
			
			// float angle = Vector3.Angle(Vector3.left, playerDir);

			// if (angle >= 30.0f && angle <= 100.0f) {
			// 	postcat.Jump();
			// 	FindObjectOfType<AudioManager>().Play("jump");
			// } else if (angle < 30.0f || angle > 100.0f) {

				
			// }
		}
	}


	void FixedUpdate() {
		rb.MoveRotation(rotSpeed * rotSpeedScale * Time.time);
	}

}
