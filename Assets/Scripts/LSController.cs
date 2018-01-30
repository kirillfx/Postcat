using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Level section controller
public class LSController : MonoBehaviour {

	void Start() {
		
	}

	public void InitializeObstacles() {
		foreach(PolyObstacle obstacle in transform.GetComponentsInChildren<PolyObstacle>()) {
			obstacle.InitializeObstacle();
		}
	}

}
