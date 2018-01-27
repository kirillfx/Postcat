using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		// Trigger Win event
		Debug.Log("Win");
	}

	
}
