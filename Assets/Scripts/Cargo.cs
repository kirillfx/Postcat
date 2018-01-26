using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour {


	void Start () {
		
	}


	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log(gameObject.name + " collided.");
		Collide();
	} 


	// Instantiate sparks, dust, reduce gas.
	void Collide() {

	}
}
