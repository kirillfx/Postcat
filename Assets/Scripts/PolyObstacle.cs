using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolyObstacle : MonoBehaviour {

	public Transform[] choices;

	void Awake() {

		int index = 0;

		if (choices != null) {
			if (choices.Length == 1) {
				index = 0;
			} else {
				index = 
					Mathf.FloorToInt(Random.RandomRange(0, choices.Length + 0.99f));
			}
		}
		
		Transform obj = choices[index];

		Instantiate(obj, transform.position, obj.rotation);

	}

}
