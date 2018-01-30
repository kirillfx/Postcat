using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CargoHealthBar : MonoBehaviour {

	public float maxHealth = 100.0f;
	public GameObject cargoObj;
	
	private Cargo cargo;
	private float currentHealth;
	private int currentSpriteIndex = 0;
	private Sprite[] sprites;
	private SpriteRenderer spriteRenderer;


	void Awake() {

		sprites = Resources.LoadAll<Sprite>("Sprites/GLASS");
		cargo = cargoObj.GetComponent<Cargo>();

	}


	void Start () {
		currentHealth = maxHealth;
	}
	

	void Update () {

		currentHealth = cargo.health;
		currentSpriteIndex = Mathf.CeilToInt((currentHealth / maxHealth) * sprites.Length);
		spriteRenderer.sprite = sprites[currentSpriteIndex];
		
	}

}
