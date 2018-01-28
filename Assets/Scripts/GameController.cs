using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public GameObject postcatObj;
	public GameState gameState;
	public Transform postcatPrefab;
	public Transform postcatPrefabWithCargo;


	private Postcat postcat;
	private Transform[] levelSections;
	private Vector3 lastSectionRoot;


	void Awake() {
		levelSections = Resources.LoadAll<Transform>("Prefab/LevelSections");
	}


	void Start() {
		StartCoroutine( StartGame() );
	}


	public void StageCleared() {
		// gameState.StoreFuel(postcat.fuel);
		// postcat.fuel = 0;
	}


	float CalcFuelForNextLevel() {
		return 100.0f;
	}


	public void GameOver() {
		// TODO: Play sound
		PauseOn();
	}

	
	public void PauseOn() {
		Time.timeScale = 0.0f;
	}


	public void PauseOff() {
		Time.timeScale = 1.0f;
	}


	IEnumerator InstantiatePostcatNoRope() {
		
		GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");
		
		postcatObj = Instantiate(
			postcatPrefab, 
			respawn.transform.position, 
			respawn.transform.rotation).gameObject;
		
		Camera.main.GetComponent<CameraController>().target = postcatObj.transform;

		// Push Postcat away from the station.
		postcatObj.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 20.0f, ForceMode2D.Impulse);
		yield return null;
	}


	public IEnumerator InstantiatePostCatWithPackage() {
		
		GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");

		postcatObj = Instantiate(
			postcatPrefabWithCargo, 
			respawn.transform.position, 
			respawn.transform.rotation).gameObject;

		Camera.main.GetComponent<CameraController>().target = postcatObj.transform.GetChild(0);
		
		yield return new WaitForSeconds(0.1f);
		// Push Postcat away from the station.

		foreach(Rigidbody2D rb in postcatObj.GetComponentsInChildren<Rigidbody2D>())
			rb.AddForce(Vector3.right * 20.0f, ForceMode2D.Impulse);
	}


	public IEnumerator StartGame() {
		
		SceneManager.LoadSceneAsync("Checkpoint", LoadSceneMode.Additive);

		GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");

		while(respawn == null) {
			respawn = GameObject.FindGameObjectWithTag("Respawn");
			yield return null;
		}

		StartCoroutine(InstantiatePostcatNoRope());
		// StartCoroutine(InstantiatePostCatWithPackage());
		
		yield return null;
	}

}
