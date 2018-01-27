using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public GameObject postcatObj;
	public GameState gameState;

	private Postcat postcat;


	void Awake() {
		postcat = postcatObj.GetComponent<Postcat>();
	}


	void Start() {
		StartCoroutine( RunGame() );
	}


	public void StageCleared() {
		gameState.StoreFuel(postcat.fuel);
		postcat.fuel = 0;
	}


	float CalcFuelForNextLevel() {
		return 100.0f;
	}


	public void GameOver() {
		PauseOn();
	}

	
	public void PauseOn() {
		Time.timeScale = 0.0f;
	}


	public void PauseOff() {
		Time.timeScale = 1.0f;
	}


	IEnumerator RunGame() {

		gameState.levelIndex = 1;

		foreach(LevelSpec levelSpec in gameState.levelSpecs) {
			
			yield return RunLevel(levelSpec);
			
			gameState.levelIndex++;
			
			yield return CheckpointScene();
		}	
		yield return null;
	}


	IEnumerator CheckpointScene() {
		// Cut scene and next level loading.
		yield return null;
	}


	IEnumerator RunLevel(LevelSpec levelSpec) {
		SceneManager.LoadSceneAsync(gameState.levelIndex, LoadSceneMode.Additive);
		yield return null;
	}
}
