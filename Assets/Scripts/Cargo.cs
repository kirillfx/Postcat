using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cargo : MonoBehaviour {

	public float health = 100.0f;
	public float damageScale = 1.0f;


	void Update () {

		// if (health <= 0)
		// 	Die();
		
	}


	void OnCollisionEnter2D(Collision2D other) {
		float m = other.otherRigidbody.velocity.magnitude;
		health  -= m * damageScale;
		
		Debug.Log(m.ToString() + " health left " + health);
	}


	void Die() {
		Destroy(this.gameObject);
	}
}
