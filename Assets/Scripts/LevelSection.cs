using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelSection : MonoBehaviour {

	private Transform[] levelSections;


	void Awake() {
		
		levelSections = Resources.LoadAll<Transform>("Prefab/LevelSections");
		
		foreach(Transform x in levelSections )
			Debug.Log(x.name);
	}


	void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject.CompareTag("Player")) {

			GameController gameController = GameObject
				.Find("GameController")
				.GetComponent<GameController>();

			gameController.loadSection = true;

			// Debug.Log("Player entered");
			// int index = Random.Range( 0, levelSections.Length );
			// Instantiate(levelSections[index], transform.position + Vector3.right * 20.0f, transform.rotation);
		}

	}


	void OnDrawGizmos() {
		Gizmos.color = Color.gray;
		Gizmos.DrawWireCube(transform.position + Vector3.right * 10.0f, Vector3.one * 20.0f);
	}

}
