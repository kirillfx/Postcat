using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Postcat/GameState")]
public class GameState : ScriptableObject {

	public LevelSpec[] levelSpecs;
	public float fuel;
	

	// Save rest of fuel for the next level.
	public void StoreFuel(float fuelRest) {
		fuel += fuelRest;
	}


	// Take fuel from balance.
	public float Take() {
		float f = fuel;
		fuel = 0;
		return f;
	}

}
