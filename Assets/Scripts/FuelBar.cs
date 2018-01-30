using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelBar : MonoBehaviour {

	public GameObject postcatObj;
	public float maxFuel = 100.0f;

	private Postcat postcat;
	private float currentFuel;
	private Slider slider;


	void Awake() {
		postcat = postcatObj.GetComponent<Postcat>();
	}


	void Start () {
	}
	

	void Update () {

		if (postcat != null) {
			currentFuel = postcat.fuel;
			slider.value = currentFuel;
		}

	}

}
