using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour {

	public Transform target;
	public float max;
	private Animation anim;


	void Awake() {
		anim = GetComponent<Animation>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float current = Mathf.Max(target.position.y, max) / max;

	}
}
