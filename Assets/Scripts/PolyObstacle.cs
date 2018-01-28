using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolyObstacle : MonoBehaviour {

	public Transform[] choices;

	void Start() {

		int index = 0;

		if (choices != null) {
			if (choices.Length == 1) {
				index = 0;
			} else {
				index = 
					index = Random.Range(0, choices.Length);
			}
		}
		
		Transform obj = choices[index];

		Instantiate(obj, transform.position, obj.rotation);

	}

	
	void OnDrawGizmos() {
		
		Gizmos.color = Color.gray;

		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}

}
