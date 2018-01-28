using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour {

	public float collisionDamageScale = 1.0f;
	public float rotSpeedScale = 1.0f;
	
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
			postcat.ApplyDamage(damage);

			Vector3 playerDir = 
				(obj.transform.position - transform.position).normalized;
			
			float angle = Vector3.Angle(Vector3.left, playerDir);

            // Sound
            FindObjectOfType<AudioManager>().Play("hitAsteroid");

			if (angle >= 30.0f && angle <= 100.0f) {
				// Debug.Log("Jump");
				postcat.Jump();
			} else if (angle < 30.0f || angle > 100.0f) {
				// Debug.Log("Crash");
				postcat.Crash();
			}
		}
	}


	void FixedUpdate() {
		rb.MoveRotation(rotSpeed * rotSpeedScale * Time.time);
	}

}
