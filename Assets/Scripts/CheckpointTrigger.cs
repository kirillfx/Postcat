using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Load Checkpoint scene on
public class CheckpointTrigger : MonoBehaviour {

	public float offsetX = 5.0f;
	
	void OnTriggerEnter2D(Collider2D col) {

		GameObject obj = col.gameObject;

		if (obj.CompareTag("Player")) {
			Debug.Log("Loading Checkpoint");
			SceneManager.LoadSceneAsync("Checkpoint", LoadSceneMode.Additive);
			StartCoroutine(Offsetter());
		}

	}


	IEnumerator Offsetter() {
		
		GameObject checkpointRoot = GameObject.Find("CheckpointRoot");

		while(checkpointRoot == null) {
			checkpointRoot = GameObject.Find("CheckpointRoot");
			yield return null;
		}


		checkpointRoot.transform.position = 
			transform.parent.position + Vector3.right * offsetX;


		yield return null;
	}

}
