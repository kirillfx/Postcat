using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public GameObject postcatObj;
	public GameState gameState;
	public Transform postcatPrefab;
	public Transform postcatPrefabWithCargo;
	public int currentLevel;
	public int startLevel;

	private bool isPaused;
	private Postcat postcat;
	private Transform[] levelSections;
	private Vector3 lastSectionRoot;


	void Awake() {
		levelSections = Resources.LoadAll<Transform>("Prefab/LevelSections");
	}


	void Start() {
		StartCoroutine( StartGame() );
	}


	public void StageCleared(float fuel, float cargoHealth, float offset) {
		gameState.StoreFuel(fuel);
		gameState.fuel += cargoHealth;
		StartCoroutine(ContinueGame(offset));
	}


	public void GameOver() {
		// TODO: Play sound
		PauseOn();
	}

	
	public void PauseOn() {
		Time.timeScale = 0.0f;
		isPaused = true;
	}


	public void PauseOff() {
		Time.timeScale = 1.0f;
		isPaused = false;
	}


	public void TogglePause() {
		if (isPaused)
			PauseOff();
		else
			PauseOn();
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

		// Get fuel from station.
		Postcat postcat = postcatObj.GetComponentInChildren<Postcat>();
		postcat.fuel = gameState.Take();

		// Set target for main camera.
		Camera.main.GetComponent<CameraController>().target = postcatObj.transform.GetChild(0);
		
		yield return new WaitForSeconds(0.1f);

		// Push Postcat away from the station.
		foreach(Rigidbody2D rb in postcatObj.GetComponentsInChildren<Rigidbody2D>())
			rb.AddForce(Vector3.right * 10.0f, ForceMode2D.Impulse);
	}


	public IEnumerator StartGame() {
		
		currentLevel = 3 + 0; // 3 is an build index offset.
		
		var loadFuture = SceneManager
			.LoadSceneAsync(currentLevel, LoadSceneMode.Additive);
		yield return new WaitUntil(() => loadFuture.isDone);
		// while(!loadFuture.isDone) 
		// 	yield return null;

		var loadCheckpointFuture = SceneManager
			.LoadSceneAsync("Checkpoint", LoadSceneMode.Additive);
		yield return new WaitUntil(() => loadCheckpointFuture.isDone);
		// while(!loadCheckpointFuture.isDone) 
		// 	yield return null;

		GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");

		StartCoroutine(InstantiatePostcatNoRope());
		
		yield return null;
	}


	public IEnumerator ContinueGame(float offset) {
		
		var unloadFuture = SceneManager.UnloadSceneAsync(currentLevel);
		while(!unloadFuture.isDone) 
			yield return null;

		var loadFuture = SceneManager
			.LoadSceneAsync(currentLevel, LoadSceneMode.Additive);
		while(!loadFuture.isDone) 
			yield return null;


		Transform levelRoot = GameObject.FindWithTag("LevelRoot").transform;
		levelRoot.transform.position = Vector3.right * (offset + 5.0f);

		yield return new WaitForSeconds(1.0f);

		// For the sake of safe spawning
		GameObject station = GameObject.FindGameObjectWithTag("Station");
		station.transform.Find("Finish").gameObject.SetActive(false);

		yield return StartCoroutine(InstantiatePostCatWithPackage());

		yield return null;
	}

}