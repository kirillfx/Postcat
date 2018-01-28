using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Process score submission;
public class CheckpointFinish : MonoBehaviour {

	GameController gameController;

	void Awake() {
		gameController = GameObject
			.Find("GameController")
			.GetComponent<GameController>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		
		GameObject obj = col.gameObject;
		
		if (obj.CompareTag("Player")) {
			
			Postcat postcat = obj.GetComponent<Postcat>();
			
			Transform cargoTransform = obj.transform.GetChild(1).GetComponent<Rope>().end;
			
			float cargoHealth = 0;
			
			if (cargoTransform != null)
				cargoHealth = cargoTransform.GetComponent<Cargo>().health;
			
			Transform checkpointRoot = GameObject.Find("CheckpointRoot").transform;

			gameController.StageCleared(
				postcat.fuel, 
				cargoHealth, 
				checkpointRoot.transform.position.x
				);
			
			Destroy(obj);

		} else if (obj.CompareTag("Cargo") || obj.CompareTag("Rope"))
			Destroy(obj);
		
	}
}
