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
		}

		gameController.StageCleared();

	}

	
}
