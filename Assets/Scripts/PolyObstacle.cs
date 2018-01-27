using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolyObstacle : MonoBehaviour {

	public Transform[] choices;

	void Awake() {
		
		int index = 
			Mathf.FloorToInt(Random.RandomRange(0, choices.Length + 1));
		
		Transform obj = choices[index];

		Instantiate(obj, transform.position, obj.rotation);

	}

}
