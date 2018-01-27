﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Postcat/GameState")]
public class GameState : ScriptableObject {

	public float fuel;
	public int stage=0;
	
	// Save rest of fuel for the next level.
	public void StoreFuel(float fuelRest) {
		fuel += fuelRest;
	}


	// Take fuel from balance.
	public float LoadFuel(float capacity) {
		if (fuel >= capacity) {
			
			fuel -= capacity;
			return capacity;

		} else {
			
			float f = fuel;
			fuel = 0;
			
			return f;
		}

	}

}