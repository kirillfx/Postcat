using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPlatform : MonoBehaviour {

	public Transform target;
	private Vector3 offset;


	void Start () {
		offset = transform.position - target.position;
	}
	

	void FixedUpdate () {
		transform.position = target.position + offset;
	}


	void OnTriggerEnter2D(Collider2D col) {
		
		GameObject obj = col.gameObject;

		if (obj.CompareTag("Player")) {
			Postcat postcat = obj.GetComponent<Postcat>();
			FindObjectOfType<AudioManager>().Play("jump");
			postcat.Jump();
		}
	}

}
