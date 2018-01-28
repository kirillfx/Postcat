using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour {

	GameController gameController;
	public float pullForce = 30.0f;


	void Start() {
		gameController = 
			GameObject.Find("GameController").GetComponent<GameController>();
	}


	// Collider that pulls objects inside station.
	void OnTriggerStay2D(Collider2D col) {

		GameObject obj = col.gameObject;
		
		if (obj.CompareTag("Player") || obj.CompareTag("Cargo")) {
			
			Postcat postcat = obj.GetComponent<Postcat>();

			// Suck Player into Station
			Vector3 dir = transform.position - obj.transform.position;
			obj.GetComponent<Rigidbody2D>().AddForce(dir * pullForce);

		}


        //TODO: возможно тоже играт что-то ...

	}


	IEnumerator Checkpoint() {
		yield return null;
	}
	
}
