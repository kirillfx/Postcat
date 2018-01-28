using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckpointTrigger : MonoBehaviour {

	public float offsetX = 10.0f;
	
	void OnTriggerEnter2D(Collider2D col) {

		GameObject obj = col.gameObject;

		if (obj.CompareTag("Player")) {
			StartCoroutine(Offsetter());
		}

	}


	IEnumerator Offsetter() {
		
		var loadFuture = SceneManager
			.LoadSceneAsync("Checkpoint", LoadSceneMode.Additive);
		yield return new WaitUntil(() => loadFuture.isDone);

		GameObject checkpointRoot = GameObject.Find("CheckpointRoot");
		checkpointRoot.transform.position = 
			transform.parent.position + Vector3.right * offsetX;

		yield return null;
	}

}
