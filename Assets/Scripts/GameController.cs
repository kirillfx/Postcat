using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public GameObject postcatObj;
	public GameState gameState;

	private Postcat postcat;
	private Transform[] levelSections;
	
	public bool loadSection;
	private Vector3 lastSectionRoot;


	void Awake() {
		postcat = postcatObj.GetComponent<Postcat>();
		levelSections = Resources.LoadAll<Transform>("Prefab/LevelSections");
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

		lastSectionRoot = Vector3.right * 2;
		gameState.levelIndex = 2;

		foreach(LevelSpec levelSpec in gameState.levelSpecs) {
			
			yield return RunLevel(levelSpec);
			
			gameState.levelIndex++;
			
			yield return CheckpointScene();
	
			gameState.levelIndex++;
		}
		

		yield return null;
	}


	IEnumerator CheckpointScene() {
		// Cut scene and next level loading.
		yield return null;
	}


	IEnumerator RunLevel(LevelSpec levelSpec) {
		// 2 is an scene index offset;
		SceneManager.LoadSceneAsync(levelSpec.levelIndex + 2, LoadSceneMode.Additive);

		// Load first section.
		int index = Random.Range( 0, levelSections.Length );
		Transform t = Instantiate(levelSections[index], lastSectionRoot + Vector3.right * 20.0f, transform.rotation);
		lastSectionRoot = t.transform.position;
		loadSection = false;
		
		// Process remaing sections.
		for(int i=1; i < levelSpec.totalSections; i++) {
			
			yield return new WaitUntil(() => loadSection);
			
			index = Random.Range( 0, levelSections.Length );
			
			t = Instantiate(levelSections[index], lastSectionRoot + Vector3.right * 20.0f, transform.rotation);
			
			loadSection = false;

			lastSectionRoot = t.transform.position;

			yield return null;
		}
		
	}
}
