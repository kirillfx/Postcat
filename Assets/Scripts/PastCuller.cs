using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PastCuller : MonoBehaviour {

	void OnTriggerExit2D(Collider2D col) {
		GameObject obj = col.gameObject;

		// Scene cleanup with delay;
		if (obj.CompareTag("Station"))
			Invoke("CleanupCheckpoint", 1.0f);
		else if (obj.CompareTag("Asteroid"))
			Destroy(obj);
	}


	void CleanupCheckpoint() {
		SceneManager.UnloadSceneAsync("Checkpoint");
	}
}
