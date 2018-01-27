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

		gameState.stage = 0;
		yield return RunStage();
		
		gameState.stage++;
		
		yield return null;
	}


	IEnumerator CheckpointScene() {
		yield return null;
	}


	IEnumerator RunStage() {
		int stageIndex = gameState.stage + 2;
		SceneManager.LoadSceneAsync(stageIndex, LoadSceneMode.Additive);
		yield return null;
	}
}
