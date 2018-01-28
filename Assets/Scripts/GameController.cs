using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public GameObject postcatObj;
	public GameState gameState;
	public Transform postcatPrefab;
	public Transform stationPrefab;

	private Postcat postcat;
	private Transform[] levelSections;
	
	public bool loadSection;
	private Vector3 lastSectionRoot;


	void Awake() {
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
		// TODO: Play sound
		PauseOn();
	}

	
	public void PauseOn() {
		Time.timeScale = 0.0f;
	}


	public void PauseOff() {
		Time.timeScale = 1.0f;
	}


	void InstantiatePostcat() {
		
		GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");
		
		postcatObj = Instantiate(
			postcatPrefab, 
			respawn.transform.position, 
			respawn.transform.rotation).gameObject;

		postcat = postcatObj.GetComponent<Postcat>();
		
		Camera.main.GetComponent<CameraController>().target = postcatObj.transform;
	}


	IEnumerator StartGame() {
		
		SceneManager.LoadScene("Checkpoint", LoadSceneMode.Additive);
		
		// yield return new WaitUntil(() => 
		// 	SceneManager.GetActiveScene().name == "Checkpoint");

		GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");

		while(respawn == null) {
			respawn = GameObject.FindGameObjectWithTag("Respawn");
			yield return null;
		}

		Debug.Log(respawn.name);
		
		postcatObj = Instantiate(
			postcatPrefab, 
			respawn.transform.position, 
			respawn.transform.rotation).gameObject;

		postcat = postcatObj.GetComponent<Postcat>();

		Camera.main.GetComponent<CameraController>().target = postcatObj.transform;
		postcatObj.GetComponent<Rigidbody2D>().AddForce(Vector3.right * 20.0f, ForceMode2D.Impulse);
		
		yield return null;
	}


	IEnumerator Checkpoint(Vector3 p) {

		// TODO: Play sound

		// Cut scene and next level loading.
		Debug.Log("Playing cutscene");
		SceneManager.LoadScene("Checkpoint", LoadSceneMode.Additive);

		yield return null;
	}



	IEnumerator RunGame() {

		lastSectionRoot = Vector3.right * 2;

		yield return StartGame();

		yield return RunLevel1();

		foreach(LevelSpec levelSpec in gameState.levelSpecs) {
			
			// yield return RunLevel(levelSpec);
			
			// yield return Checkpoint(Vector3.zero);
	
		}
		
		yield return null;
	}


	IEnumerator RunLevel1() {
		SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
		yield return new WaitForSeconds(1);
		SceneManager.UnloadSceneAsync("Checkpoint");
		yield return null;
	}


	IEnumerator RunLevel(LevelSpec levelSpec) {

		Vector3 initialOffset = Vector3.right * 2.0f;

		// TODO: Play sound

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
