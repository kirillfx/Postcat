using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTank : MonoBehaviour {

	public float fuel = 10.0f;

	void OnCollisionEnter2D(Collision2D col) {
		
		GameObject obj = col.gameObject;
		
		if (obj.CompareTag("Player")) {
			Postcat postcat = obj.GetComponent<Postcat>();
			postcat.Refuel(fuel);
		}

	}

}
