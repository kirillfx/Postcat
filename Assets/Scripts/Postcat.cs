using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Postcat : MonoBehaviour {

	public float speed = 10.0f;
	public float consumption = 0.1f;
	public float fuel = 100.0f;
	public float collisionDamageScale = 1.0f;

	Rigidbody2D rb;


	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate () {

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(h, v, 0.0f);
		
		if (fuel > 0) {
			
			rb.AddForce(movement * speed);
			
			if (movement.magnitude > 0)
				fuel -= consumption;
		}

	}


	public void ApplyAsteroidCollision(float damage) {
		fuel -= damage;
	}


	void OnCollisionEnter2D(Collision2D collision) {
		float damage = collision.relativeVelocity.magnitude * collisionDamageScale;
		fuel -= damage;
		Debug.Log("Postcat recieved damage " + damage.ToString() );
	}


	public void Refuel(float fuelAmount) {
		fuel += fuelAmount;
	}
}
