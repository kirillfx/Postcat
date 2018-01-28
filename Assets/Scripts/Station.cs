using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour {

	GameController gameController;

	void Start() {
		gameController = 
			GameObject.Find("GameController").GetComponent<GameController>();
	}


	void OnTriggerEnter2D(Collider2D col) {

		GameObject obj = col.gameObject;
		
		if (obj.CompareTag("Player")) {
			Postcat postcat = obj.GetComponent<Postcat>();

			// Suck Player into Station
			Vector3 dir = transform.position - obj.transform.position;
			obj.GetComponent<Rigidbody2D>().AddForce(dir * 10, ForceMode2D.Impulse);
		}

		gameController.StageCleared();

        //TODO: возможно тоже играт что-то ...

	}


	IEnumerator Checkpoint() {
		yield return null;
	}
	
}
