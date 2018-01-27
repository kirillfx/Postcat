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

		foreach(LevelSpec levelSpec in gameState.levelSpecs) {
			
			yield return RunLevel(levelSpec);
			
			yield return CheckpointScene();
	
		}
		

		yield return null;
	}


	IEnumerator CheckpointScene() {
		// Cut scene and next level loading.
		Debug.Log("Playing cutscene");
		yield return null;
	}


	IEnumerator RunLevel(LevelSpec levelSpec) {

		Vector3 initialOffset = Vector3.right * 2.0f;

		// Load first section.
		int index = Random.Range( 0, levelSections.Length );
		Transform t = Instantiate(levelSections[index], lastSectionRoot + initialOffset, transform.rotation);
		lastSectionRoot = t.transform.position + Vector3.right * 20.0f;
		loadSection = false;
		
		// Process remaing sections.
		for(int i=1; i < levelSpec.totalSections; i++) {
			
			yield return new WaitUntil(() => loadSection);
			
			index = Random.Range( 0, levelSections.Length );
			
			t = Instantiate(levelSections[index], lastSectionRoot, transform.rotation);
			
			loadSection = false;

			lastSectionRoot = t.transform.position + Vector3.right * 20.0f;

			yield return null;
		}
		
	}
}
