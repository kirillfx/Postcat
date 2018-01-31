using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class RootController : MonoBehaviour {

	public float max = 2;
	public float scale = 1f;
	private PlayableDirector director;
	private float currentTime = 0;


	void Awake() {
		director = GetComponent<PlayableDirector>();
	}
	

	void Update () {

		currentTime += Input.GetAxis("Horizontal") * Time.deltaTime * scale;
		currentTime = Mathf.Min(currentTime, max);

		director.time = (currentTime / max) * director.duration;
		director.Evaluate();
	}
}
