using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolyObstacle : MonoBehaviour {

	public bool initializeOnStart = false;
	public Transform[] choices;


	void Start() {
		if (initializeOnStart)
			InitializeObstacle();
	}


	public void InitializeObstacle() {
		int index = 0;

		if (choices != null) {
			if (choices.Length > 1)
				index = Random.Range(0, choices.Length);
		}
		
		Transform obj = choices[index];

		Instantiate(obj, transform.position, obj.rotation);
	}

	
	void OnDrawGizmos() {
		
		Gizmos.color = Color.gray;

		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}

}
