﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Postcat : MonoBehaviour {

	public float speedScale = 10.0f;
	public float maxSpeed = 10.0f;
	public float consumption = 0.1f;
	public float fuel = 100.0f;

	public float yBound = 8.0f;
	public float reboundForce = 1.0f;
	public float clampVelScale = 1.0f;

	Rigidbody2D rb;
	Animator animator;


	void Awake() {

		rb = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();

	}
	

	void FixedUpdate () {

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(h, v, 0.0f);

		animator.SetFloat("horizontal", h);
		animator.SetFloat("vertical", v);


		
		if (fuel > 0) {
			
			if (transform.position.y >= yBound) {
				rb.velocity = Vector3.ClampMagnitude(rb.velocity, clampVelScale);
				rb.AddForce(Vector3.up * -reboundForce);
			}
			else if (transform.position.y <= -yBound) {
				rb.velocity = Vector3.ClampMagnitude(rb.velocity, clampVelScale);
				rb.AddForce(Vector3.up * reboundForce);
			}
			else {
				rb.AddForce(movement * speedScale);
			}

			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
			
			if (movement.magnitude > 0)
				fuel -= consumption;
		}

	}


	public void ApplyDamage(float damage) {
		fuel -= damage;
	}


	public void Refuel(float fuelAmount) {
		fuel += fuelAmount;
		// TODO: Play sound
	}


	public void Jump() {
		rb.AddForce(Vector3.up * 5.0f, ForceMode2D.Impulse);
		animator.SetTrigger("Jump");
		// TODO: Play sound
	}


	public void Crash() {
		rb.AddForce(Vector3.left * 5.0f, ForceMode2D.Impulse);
		animator.SetTrigger("Crash");
		// TODO: Play sound
	}
}
