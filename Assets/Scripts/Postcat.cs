using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Postcat : MonoBehaviour {

	public float speedScale = 10.0f;
	public float maxSpeed = 10.0f;
	public float consumption = 0.1f;
	public float fuel = 100.0f;
	public float jumpForce = 10.0f;

	public float yBound = 8.0f;
	public float reboundForce = 1.0f;
	public float clampVelScale = 1.0f;

	Rigidbody2D rb;
	Animator animator;
	GameController gameController;


	void Awake() {

		rb = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();
		gameController = GameObject
			.Find("GameController")
			.gameObject
			.GetComponent<GameController>();

	}
	

	void FixedUpdate () {

		float h = Mathf.Max(0.0f, Input.GetAxis("Horizontal"));
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
		} else
			gameController.GameOver();

        // Звук двигателя
        if (Input.GetKeyDown(KeyCode.W))
        {
            FindObjectOfType<AudioManager>().Play("engine");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            FindObjectOfType<AudioManager>().Play("engine");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<AudioManager>().Play("engine");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            FindObjectOfType<AudioManager>().Play("engine");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            FindObjectOfType<AudioManager>().Play("engine");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            FindObjectOfType<AudioManager>().Play("engine");

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            FindObjectOfType<AudioManager>().Stop("engine");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            FindObjectOfType<AudioManager>().Stop("engine");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            FindObjectOfType<AudioManager>().Stop("engine");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            FindObjectOfType<AudioManager>().Stop("engine");
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            FindObjectOfType<AudioManager>().Stop("engine");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            FindObjectOfType<AudioManager>().Stop("engine");
        }
    }


	public void ApplyDamage(float damage) {
		fuel -= damage;
	}


	public void Refuel(float fuelAmount) {
		fuel += fuelAmount;        
	}


	public void Jump() {
		rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
		animator.SetTrigger("Jump");
    }


	public void Crash() {
		rb.AddForce(Vector3.left * 5.0f, ForceMode2D.Impulse);
		animator.SetTrigger("Crash");
	}
}
